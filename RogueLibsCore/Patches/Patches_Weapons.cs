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

                if (hitObj is ObjectReal objectReal)
                {
                    // Add sprites to the objectList
                    // #multiplayer-sync
                    // if (can't hit) return

                    // if (it's a window)
                    //   if (damage >= 30)
                    //     justHitWindow = true
                    //   if (Silent Vandalizer trait)
                    //     suppress window breaking sounds

                    // if (not real object or melee can't hit it) return
                    // damage the object
                    // spawn noise
                    // OwnCheck
                    // reset justHitWindow
                    // spawn particles
                    // shake the screen, enable freeze frames and stuff
                    // #multiplayer-sync


                }
                else if (hitObj is Agent agent)
                {
                    // add opponent to the objectList
                    // #multiplayer-sync
                    // if (can't hit) return

                    // if (weapon can't hit and target not dead)
                    //   do stealing and chloroforming (HitAftermath)
                    //   spawn noise if unsuccessful

                    // if (weapon can't hit) return
                    // if (opponent's aligned with the attacker,
                    //     and one of them has that one trait) return

                    // add opponent's melee to the objectList
                    // infect the opponent if the attacker's a zombie

                    // handle FleshFeast traits

                    // if (opponent not dead and has health)
                    //   do actual damage to the opponent

                    // alert attacker's followers to attack
                    // handle AttacksDamageAttacker traits

                    // if (opponent just died)
                    //   maybe turn on slow motion

                    // do knockback
                    // handle ProtectiveShell ability
                    //   with a chance to knock weapons

                    // #multiplayer-sync
                    // shake the screen
                    // set AI combat cooldown
                    // if (server) spawn noise
                    // #MeleeHitEffect

                    // vibrate the controller
                    // tutorial trigger



                }
                else if (hitObj is Item item)
                {
                    // add item to the objectList
                    // #multiplayer-sync

                    // if (throwing) return
                    // if (weapon can't hit item) return

                    // do knockback
                    // do damage to the item
                    // trigger item's effects
                    // set item's thrower

                    // spawn noise
                    // OwnCheck
                    // ignore collision with the thrower
                    // #MeleeHitEffect
                    // vibrate the controller
                    // #multiplayer-sync



                }
                else if (hitObj is Melee melee)
                {
                    // add melee to the objectList
                    // if (any of the melees is a stealing glove or a chloroform hankie) return
                    // #multiplayer-sync

                    // if (opponent's aligned with the attacker
                    //     and one of them has that one trait) return

                    // if (same person or weapon can't hit the opponent) return
                    // if (neither of them is giant or shrunk) return ???

                    // add melee's agent to the objectList
                    // add my melee and agent to the other melee's objectList

                    // find and clamp damage
                    // #multiplayer-sync
                    // if (#multiplayer-something)
                    //   knockback my agent
                    //   if (server?)
                    //     knockback my opponent
                    // #multiplayer-sync
                    // if (neither of them is a ghost)
                    //   if (one has a weapon and the other doesn't)
                    //     subtract 1 health from the one without a weapon

                    // deplete 5 melee from both
                    // #MeleeHitEffect

                    // shake the screen, enable freeze frames and stuff
                    // alert the cops
                    // vibrate the controller
                    // set the AI combat cooldown
                    // if (server) spawn noise
                    // if (melee emitted particles)
                    //   spawn ObjectDestroyed particles

                    // handle KnockWeapons traits



                }
                else if (hitObj is Bullet bullet)
                {
                    // add bullet to the objectList



                }
                else if (isWall)
                {
                    // add wall to the objectList
                    // if (weapon already hit a wall or weapon can't hit) return
                    // hitWall = true
                    // find damage that the attacker would deal to themselves ???
                    // if (attacker is a giant)
                    //   set damage to 200
                    //   if (wall is not steel)
                    //     hitWall = false
                    //     (allowing multiple weak walls to be destroyed)

                    // determine the wall destruction thresholds

                    // if (damage >= minimum threshold)
                    //   get tile data
                    //   if (damage >= material threshold)
                    //     destroy tile
                    //     play wall destruction sound
                    //     set wall's layer to 1 ??? (destroyed walls layer?)
                    //     add destruction points, if it's not a border wall
                    //     add destruction stats
                    //     shake the screen and enable freeze frames

                    //     deplete 10 or 20 melee

                    // if (weapon emitted particles)
                    //   spawn ObjectDestroyed particles

                    // if (no Silent Vandalizer and not a stealth attack)
                    //   spawn noise
                    //   if (destroyed a wall)
                    //     spawn noise at the wall's location

                    // if (destroyed a wall)
                    //   OwnCheck

                    // play BulletHitWall sound
                    // vibrate the controller
                    // #multiplayer-sync



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
