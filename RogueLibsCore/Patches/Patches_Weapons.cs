using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchWeapons()
        {
            Patcher.Transpiler(typeof(Melee), nameof(Melee.Attack), new Type[1] { typeof(bool) });

            Patcher.Prefix(typeof(Melee), "DisableFailsafe");
            Patcher.Prefix(typeof(MeleeContainer), nameof(MeleeContainer.stopMeleeAnim));

        }

        public static IEnumerable<CodeInstruction> Melee_Attack(IEnumerable<CodeInstruction> codeEnumerable)
        {
            List<CodeInstruction> code = new List<CodeInstruction>(codeEnumerable);

            // find the last Melee.SetWeaponCooldown call
            MethodInfo meleeSetWeaponCooldown = typeof(Melee).GetMethod(nameof(Melee.SetWeaponCooldown))!;
            int lastSetWeaponCooldown = code.FindLastIndex(i => i.Calls(meleeSetWeaponCooldown));

            int beginReplace = lastSetWeaponCooldown - 2; // include loading this and 1f
            int startSearch = lastSetWeaponCooldown + 1;
            int endSearch = code.Count - 1;

            FieldInfo meleeAnimClass = typeof(Melee).GetField(nameof(Melee.animClass));

            // search for the last `this.animClass = "Fist";`
            int lastAnimClassAssign;
            for (;;)
            {
                lastAnimClassAssign = code.FindLastIndex(endSearch, code.Count - startSearch, i => i.StoresField(meleeAnimClass));
                CodeInstruction presumedLdStrFist = code[lastAnimClassAssign - 1];
                CodeInstruction presumedLdArg0 = code[lastAnimClassAssign - 2];

                if (presumedLdArg0.opcode == OpCodes.Ldarg_0
                    && presumedLdStrFist.opcode == OpCodes.Ldstr && (string)presumedLdStrFist.operand == "Fist")
                {
                    break; // found the line
                }
                endSearch = lastAnimClassAssign - 1;
            }
            int endReplaceExclusive = lastAnimClassAssign + 1;

            // save the labels of the first instruction
            CodeInstruction labeledLdArg0 = code[beginReplace];
            // remove the entire branch
            code.RemoveRange(beginReplace, endReplaceExclusive - beginReplace);

            // insert our own branch
            code.InsertRange(beginReplace, new CodeInstruction[]
            {
                labeledLdArg0,
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(RogueLibsPlugin), nameof(Melee_Attack_Helper))),
            });

            return code;
        }
        private static void Melee_Attack_Helper(Melee __instance)
        {
            CustomWeaponMelee? custom = __instance.agent.inventory.equippedWeapon?.GetHook<CustomWeaponMelee>();
            if (custom is not null)
            {
                MeleeAttackInfo? info = custom.StartAttack();
                if (info is not null)
                {
                    MeleeAttackInfo.AnimationInfo anim = info.Animation;
                    MeleeAttackInfo.ParticlesInfo particles = info.Particles;

                    __instance.meleeContainerAnim.speed = info.Speed;

                    MeleeHands hands = info.Hands;
                    __instance.realArm1.enabled = (hands & MeleeHands.Left) is 0;
                    __instance.realArm2.enabled = (hands & MeleeHands.Right) is 0;
                    __instance.twoHandSwing = (hands & MeleeHands.Both) == MeleeHands.Both;
                    if (anim.Sound is not null)
                        __instance.gc.audioHandler.Play(__instance.agent, anim.Sound);

                    __instance.SetWeaponCooldown(1f);
                    __instance.canMove = info.CanMoveDuringAttack;
                    __instance.agent.movement.KnockForward(__instance.agent.tr.rotation, info.KnockForce, true);

                    __instance.meleeHitbox.boxColliderDefaultOffsetX = info.HitBox.x;
                    __instance.meleeHitbox.boxColliderDefaultOffsetY = info.HitBox.y;
                    __instance.meleeHitbox.boxColliderDefaultSizeX = info.HitBox.width;
                    __instance.meleeHitbox.boxColliderDefaultSizeY = info.HitBox.height;

                    string animClass = info.Type switch
                    {
                        MeleeAttackType.Fist => "Fist",
                        MeleeAttackType.Claw => "Claw",
                        MeleeAttackType.Stab => "Stab",
                        MeleeAttackType.Swing => "Swing",
                        _ => throw new InvalidOperationException($"Invalid {nameof(MeleeAttackType)} value: {info.Type}."),
                    };
                    if (__instance.specialLunge) animClass += "Lunge";
                    __instance.animClass = animClass;

                    if (__instance.mustDoBackstab && info.CanBackstab)
                    {
                        __instance.meleeContainerAnim.Play("Melee-Knife", -1, 0f);
                    }
                    else
                    {
                        if (anim.Name is not null) __instance.meleeContainerAnim.Play(anim.Name, -1, 0f);

                        if (particles.Name is not null)
                        {
                            __instance.particles = __instance.gc.spawnerMain.SpawnParticleEffect(particles.Name,
                                __instance.meleeHitbox.tr.position, particles.Angle);
                            __instance.particles.transform.SetParent(__instance.meleeHitbox.tr);
                            __instance.particles.transform.localPosition = particles.Offset;
                        }
                    }
                    __instance.hitParticlesTr.localPosition = new Vector3(0f, 0.3f, 0f);
                }
            }
            else
            {
                RogueFramework.LogError($"Triggered an unknown non-custom weapon! {__instance.agent.inventory.equippedWeapon?.invItemName}");
            }
        }

        public static bool Melee_DisableFailsafe(out IEnumerator __result)
        {
            __result = Array.Empty<object>().GetEnumerator();
            return false;
        }
        public static void MeleeContainer_stopMeleeAnim(MeleeContainer __instance)
        {
            CustomWeaponMelee? custom = __instance.melee.agent.inventory.equippedWeapon?.GetHook<CustomWeaponMelee>();
            custom?.EndAttack();
        }

        public static bool MeleeHitbox_HitObject(MeleeHitbox __instance, GameObject hitObject, bool fromClient)
        {
            static void RewrittenOriginal(MeleeHitbox me, GameObject hitGO, bool fromClient)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;
                InvItem? weaponItem = myAgent.inventory.equippedWeapon;
                if (weaponItem is null || weaponItem.itemType == ItemTypes.WeaponProjectile)
                    weaponItem = myAgent.inventory.fist;
                CustomWeaponMelee? custom = weaponItem?.GetHook<CustomWeaponMelee>();

                PlayfieldObject hitObj;
                #region Determine the object's type
                bool isWall = false;
                if (hitGO.CompareTag("ObjectRealSprite"))
                {
                    hitObj = hitGO.name.Contains("ExtraSprite")
                        ? hitGO.transform.parent.transform.parent.GetComponent<ObjectReal>()
                        : hitGO.GetComponent<ObjectSprite>().objectReal;
                }
                else if (hitGO.CompareTag("AgentSprite"))
                {
                    hitObj = hitGO.GetComponent<ObjectSprite>().agent;
                }
                else if (hitGO.CompareTag("ItemImage"))
                {
                    hitObj = hitGO.transform.parent.GetComponent<Item>();
                }
                else if (hitGO.CompareTag("MeleeHitbox"))
                {
                    hitObj = hitGO.GetComponent<MeleeColliderBox>().meleeHitbox.myMelee;
                }
                else if (hitGO.CompareTag("BulletHitbox"))
                {
                    return; // TODO
                }
                else if (hitGO.CompareTag("Wall"))
                {
                    isWall = true;
                    return; // TODO
                }
                else
                {
                    return; // TODO
                }
                #endregion
                #region #multiplayer-sync
                if (gc.multiplayerMode && gc.serverPlayer && !myAgent.localPlayer && !fromClient && myAgent.isPlayer != 0)
                {
                    if (hitObj is ObjectReal objectRealSync)
                    {
                        if (objectRealSync is Window window)
                        {
                            if (window.FindDamage(myMelee, false, true, fromClient) < 30 && window.hitWindowOnce) return;
                            me.justHitWindow = true;
                        }
                        if (!objectRealSync.objectSprite.meshRenderer.enabled || !objectRealSync.notRealObject || !objectRealSync.OnFloor
                            || !objectRealSync.meleeCanPass || !objectRealSync.tempNoMeleeHits)
                        {
                            return;
                        }
                    }
                    bool flag = hitObj is ObjectReal or Agent or Item || isWall;
                    if (hitObj is Agent agent)
                        flag = agent != myAgent && !(agent.localPlayer && myAgent.isPlayer > 0 && !myAgent.localPlayer);
                    if (flag)
                    {
                        me.FakeHit(hitGO);
                        return;
                    }
                }
                #endregion

                GameObject originalGO = hitGO;
                PlayfieldObject originalObj = hitObj;

                #region Handle BlocksSometimesHit traits
                if (hitObj is Melee meleeBlocksHit)
                {
                    if (myAgent.statusEffects.hasTrait("BlocksSometimesHit2") && gc.percentChance(60)
                        || myAgent.statusEffects.hasTrait("BlocksSometimesHit") && gc.percentChance(30))
                    {
                        hitObj = meleeBlocksHit.agent;
                        hitGO = meleeBlocksHit.agent.agentHitboxScript.go;
                    }
                    else
                    {
                        Agent otherAgent = meleeBlocksHit.agent;
                        if (otherAgent.statusEffects.hasTrait("BlocksSometimesHit2") && gc.percentChance(60)
                            || otherAgent.statusEffects.hasTrait("BlocksSometimesHit") && gc.percentChance(30))
                        {
                            hitObj = myAgent; // TODO: What? There's a check in the agent branch that ensures you can't hit yourself
                            hitGO = myAgent.agentHitboxScript.go;
                        }
                    }
                }
                #endregion


                // CustomWeaponMelee.PreHit(pre)


                if (hitObj is ObjectReal objectReal)
                {
                    // #multiplayer-sync
                    // if (weapon's sprite is disabled) return
                    // if (!pre.IgnoreLOS && not in LOS) return

                    // if (it's a window)
                    //   if (damage >= 30)
                    //     justHitWindow = true
                    //   if (Silent Vandalizer trait)
                    //     suppress window breaking sounds

                    // if (not real object or melee can't hit it) return

                    // damage the object // pre.WeaponDamage

                    // CustomWeaponMelee.Hit(e)

                    // spawn noise // e.Noise
                    // OwnCheck // e.OwnCheck
                    // reset justHitWindow
                    // spawn particles // e.Particles
                    // shake the screen, enable freeze frames and stuff // e.ShakeScreen, e.FreezeFrames
                    // #multiplayer-sync

                    // finally { Add sprites to the objectList } // e.CanHitAgain

                }
                else if (hitObj is Agent agent)
                {
                    // #multiplayer-sync
                    // if (same person, attacked is a ghost, or !pre.IgnoreLOS && not in LOS) return

                    // if (!pre.IgnoreAlignedCheck && aligned trait active) return
                    // (stealing and chloroforming bypass the aligned check in vanilla)

                    // if (weapon.meleeNoHit)
                    //   if (target not dead)
                    //     do stealing and chloroforming (HitAftermath)
                    //     CustomWeaponMelee.Hit(e), I guess? // TODO
                    //     spawn noise if unsuccessful
                    //   return

                    // infect the opponent if the attacker's a zombie
                    // handle FleshFeast traits

                    // if (opponent not dead and has health && pre.WeaponDamage != 0)
                    //   do actual damage to the opponent

                    // CustomWeaponMelee.Hit(e)

                    // alert attacker's followers to attack
                    // handle AttacksDamageAttacker traits

                    // if (opponent just died)
                    //   maybe turn on slow motion

                    // do knockback // e.Knockback
                    // handle ProtectiveShell ability
                    //   with a chance to knock weapons

                    // #multiplayer-sync
                    // shake the screen // e.ShakeScreen
                    // set AI combat cooldown // e.AICombatCooldown
                    // if (server) spawn noise // e.Noise
                    // #MeleeHitEffect

                    // vibrate the controller // e.VibrateController
                    // tutorial trigger

                    // finally { add opponent's melee to the objectList } // if (!weapon.meleeNoHit) // e.CanHitAgain

                    // finally { add opponent to the objectList } // e.CanHitAgain



                }
                else if (hitObj is Item item)
                {
                    // #multiplayer-sync

                    // if (throwing) return
                    // if (weapon.meleeNoHit) return
                    // if (!pre.IgnoreLOS && not in LOS) return

                    // CustomWeaponMelee.Hit(e)

                    // do knockback // e.Knockback
                    // do damage to the item // pre.WeaponDamage
                    // trigger item's effects // e.TriggerItems
                    // set item's thrower

                    // spawn noise // e.Noise
                    // OwnCheck // e.OwnCheck
                    // ignore collision with the thrower for a bit
                    // #MeleeHitEffect
                    // vibrate the controller // e.VibrateController
                    // #multiplayer-sync

                    // finally { add item to the objectList } // e.CanHitAgain



                }
                else if (hitObj is Melee melee)
                {
                    // ~~if (any of the melees is a stealing glove or a chloroform hankie) return~~
                    // if (any of the weapons has meleeNoHit) return // TODO: should be pretty much equivalent to the previous line?
                    // #multiplayer-sync

                    // if (!pre.IgnoreAlignedCheck && aligned trait active) return

                    // if (same person, or meleeNoHit, or !pre.IgnoreLOS && not in LOS) return
                    // if (neither of them is giant or shrunk) return // TODO: why is this check needed?

                    // try (for the first two finally blocks)

                    // find and clamp damage (e.WeaponDamage)

                    // CustomWeaponMelee.Hit(e)

                    // #multiplayer-sync
                    // if (#multiplayer-something)
                    //   knockback my agent // e.Recoil
                    //   if (server?)
                    //     knockback my opponent // e.Knockback
                    // #multiplayer-sync
                    // if (neither of them is a ghost)
                    //   if (one has a weapon and the other doesn't)
                    //     subtract 1 health from the one without a weapon

                    // deplete 5 melee from both // e.DepleteAmount
                    // #MeleeHitEffect

                    // shake the screen, enable freeze frames and stuff // e.ShakeScreen, e.FreezeFrames
                    // alert the cops
                    // vibrate the controller // e.VibrateController
                    // set the AI combat cooldown // e.AICombatCooldown
                    // if (server) spawn noise // e.Noise
                    // if (melee emitted particles)
                    //   spawn ObjectDestroyed particles // e.Particles

                    // handle KnockWeapons traits

                    // finally { add melee's agent to the objectList } (#try) // e.CanHitAgain
                    // finally { add my melee and agent to the other melee's objectList } (#try) // e.CanHitAgain

                    // finally { add melee to the objectList } // e.CanHitAgain



                }
                else if (hitObj is Bullet bullet)
                {
                    // add bullet to the objectList



                }
                else if (isWall)
                {
                    // if (weapon already hit a wall or meleeNoHit or !pre.IgnoreLOS && not in LOS) return
                    // hitWall = true

                    // find damage that the attacker would deal to themselves ???
                    // TODO: should be determined before CustomWeaponMelee.PreHit(pre)?
                    // if (attacker is a giant)
                    //   set damage to 200
                    //   if (wall is not steel)
                    //     hitWall = false (allowing multiple weak walls to be destroyed)

                    // CustomWeaponMelee.Hit(e)

                    // determine the wall destruction thresholds

                    // if (damage >= minimum threshold)
                    //   get tile data
                    //   if (damage >= material threshold)
                    //     destroy tile
                    //     play wall destruction sound
                    //     set wall's layer to 1 ??? (destroyed walls layer?)
                    //     add destruction points, if it's not a border wall
                    //     add destruction stats
                    //     shake the screen and enable freeze frames // e.ShakeScreen, e.FreezeFrames

                    //     deplete 10 or 20 melee // e.DepleteAmount

                    // if (weapon emitted particles)
                    //   spawn ObjectDestroyed particles // e.Particles

                    // if (no Silent Vandalizer and not a stealth attack)
                    //   spawn noise // e.Noise
                    //   if (destroyed a wall)
                    //     spawn noise at the wall's location

                    // if (destroyed a wall)
                    //   OwnCheck // e.OwnCheck

                    // play BulletHitWall sound // e.Sound
                    // vibrate the controller // e.VibrateController
                    // #multiplayer-sync

                    // finally { add wall to the objectList } // e.CanHitAgain



                }
                else
                {
                    return;
                }



            }

            RewrittenOriginal(__instance, hitObject, fromClient);
            return false;
        }

    }
}
