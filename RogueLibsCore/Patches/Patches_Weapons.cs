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
            Patcher.Postfix(typeof(Melee), nameof(Melee.ShowMelee));
            Patcher.Postfix(typeof(MeleeHitbox), nameof(MeleeHitbox.RevertAllVars));
            Patcher.Postfix(typeof(MeleeHitbox), nameof(MeleeHitbox.SetDisabled));

            Patcher.Prefix(typeof(MeleeHitbox), nameof(MeleeHitbox.HitObject));

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

        public static void Melee_ShowMelee(Melee __instance) => __instance.GetHook<MeleeHitHook>()?.Clear();
        public static void MeleeHitbox_RevertAllVars(MeleeHitbox __instance) => __instance.myMelee.GetHook<MeleeHitHook>()?.Clear();
        public static void MeleeHitbox_SetDisabled(MeleeHitbox __instance) => __instance.myMelee.GetHook<MeleeHitHook>()?.Clear();

        public static bool MeleeHitbox_HitObject(MeleeHitbox __instance, GameObject hitObject, bool fromClient)
        {
            RewrittenOriginal(__instance, hitObject, fromClient);
            return false;

            static void RewrittenOriginal(MeleeHitbox me, GameObject hitGO, bool fromClient)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;
                InvItem weaponItem = myAgent.inventory.equippedWeapon ?? myAgent.inventory.fist;
                if (weaponItem.itemType == ItemTypes.WeaponProjectile)
                    weaponItem = myAgent.inventory.fist;
                CustomWeaponMelee? custom = weaponItem.GetHook<CustomWeaponMelee>();

                PlayfieldObject hitObj;
                #region Set hitObj
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

                #region Handle hit detection
                MeleeHitHook hitsHook = myMelee.GetOrAddHook<MeleeHitHook>();
                bool firstHit = hitsHook.IsFirstHit(hitObj);
                if (!firstHit && !hitsHook.CanHitAgain(hitObj)) return;

                MeleePreHitArgs pre = new MeleePreHitArgs(hitGO, hitObj, originalGO, originalObj, firstHit, fromClient);

                // (stealing and chloroforming bypass the aligned check in vanilla)
                if (weaponItem?.invItemName is VanillaItems.StickyGlove or VanillaItems.ChloroformHankie)
                    pre.IgnoreAlignedCheck = true;

                custom?.PreHit(pre); // the attack can be redirected only once // TODO: review

                hitGO = pre.GameObject;
                hitObj = pre.Target;
                firstHit = hitsHook.IsFirstHit(hitObj);
                if (!firstHit && !hitsHook.CanHitAgain(hitObj)) return;

                hitsHook.RegisterHit(hitObj);

                if (pre.IsDefaultPrevented) return; // CustomWeaponMelee will take care of the entire attack sequence
                #endregion

                InvItem? otherWeapon = null;
                CustomWeaponMelee? otherCustomWeapon = null;
                if (hitObj is Melee melee2)
                {
                    otherWeapon = melee2.agent.inventory.equippedWeapon ?? melee2.agent.inventory.fist;
                    if (otherWeapon.itemType == ItemTypes.WeaponProjectile)
                        otherWeapon = melee2.agent.inventory.fist;
                    otherCustomWeapon = otherWeapon.GetHook<CustomWeaponMelee>();
                }

                #region Actual hit and type-specific stuff
                MeleeHitArgs e = new MeleeHitArgs(pre);
                MeleeHitArgs? eOther = null;

                Action? cleanUpAction = null;
                if (hitObj is ObjectReal objectReal)
                    cleanUpAction = HitObjectReal(me, objectReal, pre, e);
                else if (hitObj is Agent agent)
                    cleanUpAction = HitAgent(me, agent, pre, e);
                else if (hitObj is Item item)
                    cleanUpAction = HitItem(me, item, pre, e);
                else if (hitObj is Melee melee)
                {
                    GameObject myGO = melee.gameObject;
                    MeleePreHitArgs preOther = new MeleePreHitArgs(myGO, melee, myGO, melee, pre.IsFirstHit, pre.FromClient);
                    eOther = new MeleeHitArgs(preOther);
                    Action? a = HitMelee(me, melee, pre, e);
                    if (a is not null)
                    {
                        Action? b = HitMelee(melee.meleeHitbox, myMelee, preOther, eOther);
                        if (b is not null)
                        {
                            cleanUpAction = () => { a(); b(); };
                        }
                    }

                }
                else if (hitObj is Bullet bullet)
                    cleanUpAction = HitBullet(me, bullet, pre, e);
                else if (isWall)
                    cleanUpAction = HitWall(me, pre, e);
                else return;
                #endregion

                try
                {
                    if (cleanUpAction != null)
                    {
                        try
                        {
                            custom?.Hit(e);
                            if (otherCustomWeapon is not null)
                            {
                                otherCustomWeapon.Hit(eOther!);
                                eOther!.MergeInto(e);
                            }
                        }
                        catch (Exception err)
                        {
                            // TODO
                        }

                        // General clean up
                        me.justHitWindow = false;

                        e.DoSideEffects(myMelee, myAgent);
                        eOther?.DoSideEffects(myMelee, myAgent);

                        me.MeleeHitEffect(hitGO); // TODO: MeleeHitEffect ?
                    }
                }
                finally
                {
                    if (hitObj is Agent agent)
                    {
                        MeleeHitHook otherHits = agent.melee.GetOrAddHook<MeleeHitHook>();
                        hitsHook.RegisterHit(agent);
                        if (e.CanHitAgain) hitsHook.SetCanHitAgain(agent);

                        if (!weaponItem!.meleeNoHit && !otherWeapon!.meleeNoHit)
                        {
                            hitsHook.RegisterHit(agent.melee);
                            otherHits.RegisterHit(myAgent);
                            otherHits.RegisterHit(myMelee);
                            if (e.CanHitAgain)
                            {
                                hitsHook.SetCanHitAgain(agent.melee);
                                otherHits.SetCanHitAgain(myAgent);
                                otherHits.SetCanHitAgain(myMelee);
                            }
                        }
                    }
                    else if (hitObj is Melee otherMelee)
                    {
                        MeleeHitHook otherHits = otherMelee.GetOrAddHook<MeleeHitHook>();
                        hitsHook.RegisterHit(otherMelee);

                        if (!weaponItem!.meleeNoHit && !otherWeapon!.meleeNoHit)
                        {
                            hitsHook.RegisterHit(otherMelee.agent);
                            otherHits.RegisterHit(myAgent);
                            otherHits.RegisterHit(myMelee);
                            if (e.CanHitAgain)
                            {
                                hitsHook.SetCanHitAgain(otherMelee.agent);
                                otherHits.SetCanHitAgain(myAgent);
                                otherHits.SetCanHitAgain(myMelee);
                            }
                        }
                    }
                    else if (isWall)
                    {
                        // TODO: wrapper class ???
                    }
                    else // default: Item, ObjectReal
                    {
                        hitsHook.RegisterHit(hitObj);
                        if (e.CanHitAgain) hitsHook.SetCanHitAgain(hitObj);
                    }
                }

            }

            static Action? HitObjectReal(MeleeHitbox me, ObjectReal objectReal, MeleePreHitArgs pre, MeleeHitArgs e)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;
                InvItem weaponItem = myAgent.inventory.equippedWeapon ?? myAgent.inventory.fist;
                if (weaponItem.itemType == ItemTypes.WeaponProjectile)
                    weaponItem = myAgent.inventory.fist;
                CustomWeaponMelee? custom = weaponItem.GetHook<CustomWeaponMelee>();

                #region #multiplayer-sync
                if (!gc.serverPlayer && !myAgent.localPlayer && myAgent.mindControlAgent != gc.playerAgent
                    && objectReal.objectSprite.meshRenderer.enabled && !objectReal.notRealObject && !objectReal.OnFloor
                    && !objectReal.meleeCanPass && !objectReal.tempNoMeleeHits)
                {
                    me.FakeHit(e.GameObject);
                    return null;
                }
                #endregion

                #region ObjectReal pre-conditions and checks
                if (!objectReal.objectMeshRenderer.enabled) return null;
                if (!pre.IgnoreLineOfSight && !me.HasLOSMelee(objectReal)) return null;

                bool noNoiseTrait = myAgent.statusEffects.hasTrait("HitObjectsNoNoise");
                if (objectReal is Window window)
                {
                    if (objectReal.FindDamage(myMelee, false, true, e.FromClient) >= 30)
                        me.justHitWindow = true;
                    if (noNoiseTrait) // TODO: make it an option to suppress breaking sounds as well?
                        window.StartCoroutine(window.TempNoNoise());
                }

                if (objectReal.notRealObject || objectReal.OnFloor || objectReal.meleeCanPass && !me.justHitWindow
                    || objectReal.tempNoMeleeHits)
                {
                    return null;
                }
                #endregion

                objectReal.Damage(myMelee, e.FromClient); // TODO: make pre.WeaponDamage affect this
                e.DamageDealt = objectReal.damagedAmount;

                #region ObjectReal hit parameters
                // set noise
                e.NoisePosition = objectReal.FindDamageNoisePos(objectReal.tr.position);
                e.NoiseVolume = objectReal.noDamageNoise || myMelee.successfullySleepKilled || noNoiseTrait ? 0 : objectReal.noiseHitVol;
                // set particles
                if (myMelee.hitParticlesTr != null && myMelee.meleeContainerTr != null)
                {
                    e.Particles = "ObjectDestroyed";
                    e.ParticlesPosition = myMelee.hitParticlesTr.position;
                    e.ParticlesAngle = myMelee.meleeContainerTr.eulerAngles.z - 90f;
                }

                // set screen shake, freeze frames, vibration and AlienFX
                if (myAgent.isPlayer > 0)
                {
                    if (myAgent.localPlayer)
                    {
                        bool impactful = !objectReal.noDestroyEffects && (objectReal.destroying || objectReal.justDamaged);
                        e.ScreenShakeTime = impactful ? 0.2f : 0.1f;
                        e.ScreenShakeOffset = 80f;
                        e.FreezeFrames = impactful ? 2 : 1;
                    }
                    e.VibrateControllerIntensity = Mathf.Clamp(objectReal.damagedAmount / 100f + 0.05f, 0f, 0.25f);
                    e.VibrateControllerTime = Mathf.Clamp(objectReal.damagedAmount / 132f + 0.05f, 0f, 0.2f);
                    e.AlienFX = true;
                }
                // set own check
                e.DoOwnCheck = gc.serverPlayer;
                #endregion

                return () =>
                {
                    #region #multiplayer-sync
                    if (!gc.serverPlayer && (myAgent.isPlayer > 0 || myAgent.mindControlAgent == gc.playerAgent))
                    {
                        if (myAgent.isPlayer != 0) myAgent.objectMult.CallCmdMeleeHitObjectReal(e.Target.objectNetID);
                        else gc.playerAgent.objectMult.CallCmdMeleeHitObjectRealNPC(myAgent.objectNetID, e.Target.objectNetID);
                    }
                    else if (gc.serverPlayer && gc.multiplayerMode)
                        myAgent.objectMult.CallRpcMeleeHitObjectFake(e.Target.objectNetID);
                    #endregion
                };
            }
            static Action? HitAgent(MeleeHitbox me, Agent agent, MeleePreHitArgs pre, MeleeHitArgs e)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;
                InvItem weaponItem = myAgent.inventory.equippedWeapon ?? myAgent.inventory.fist;
                if (weaponItem.itemType == ItemTypes.WeaponProjectile)
                    weaponItem = myAgent.inventory.fist;
                CustomWeaponMelee? custom = weaponItem.GetHook<CustomWeaponMelee>();

                #region #multiplayer-sync
                if (gc.multiplayerMode)
                {
                    if (gc.serverPlayer && myAgent.localPlayer && agent.isPlayer > 0 && !agent.localPlayer)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (gc.serverPlayer && myAgent.isPlayer == 0 && agent.isPlayer > 0 && !agent.localPlayer)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (gc.multiplayerMode && gc.serverPlayer && myAgent.isPlayer == 0 && agent.isPlayer == 0
                        && myAgent.mindControlAgent != null && myAgent.mindControlAgent != gc.playerAgent && !agent.dead)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (gc.multiplayerMode && gc.serverPlayer && myAgent.isPlayer == 0 && agent.isPlayer == 0
                        && agent.mindControlAgent != null && agent.mindControlAgent != gc.playerAgent && !agent.dead)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (!gc.serverPlayer && myAgent.isPlayer == 0 && !agent.localPlayer && myAgent != agent
                        && (myAgent.mindControlAgent != gc.playerAgent && agent.mindControlAgent != gc.playerAgent || agent.dead))
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (!gc.serverPlayer && myAgent.isPlayer > 0 && !myAgent.localPlayer && !agent.localPlayer)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (!gc.serverPlayer && (myAgent.localPlayer || myAgent.mindControlAgent == gc.playerAgent)
                                         && agent.isPlayer > 0 && !agent.localPlayer)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                    if (!gc.serverPlayer && myAgent.isPlayer != 0 && !myAgent.localPlayer && agent.isPlayer != 0 && !agent.localPlayer)
                    {
                        me.FakeHit(e.GameObject);
                        return null;
                    }
                }
                #endregion

                #region Agent pre-conditions and checks
                if (agent == myAgent || agent.ghost || agent.fellInHole || gc.cinematic
                    || !pre.IgnoreLineOfSight && !me.HasLOSMelee(agent)) return null;
                // TODO: make ghost and cinematic checks configurable
                if (!pre.IgnoreAlignedCheck && !myAgent.DontHitAlignedCheck(agent)) return null;
                #endregion

                if (weaponItem!.meleeNoHit)
                {
                    if (!agent.dead)
                    {
                        #region Stealing and chloroforming
                        // TODO: do stealing and chloroforming (HitAftermath)
                        // spawn noise if unsuccessful
                        #endregion
                    }
                }
                else
                {
                    if (gc.serverPlayer || agent.health > 0f || agent.dead)
                    {
                        agent.Damage(myMelee, e.FromClient); // TODO: make pre.WeaponDamage affect this
                        e.DamageDealt = agent.damagedAmount;
                    }

                    #region Agent hit parameters
                    // set knockback strength
                    if (myMelee.successfullySleepKilled || myMelee.successfullyBackstabbed)
                        e.KnockbackStrength = 0f;
                    else if ((!agent.dead || agent.justDied) && !agent.disappeared)
                        e.KnockbackStrength = Mathf.Clamp(e.DamageDealt * 20f, 80f, 9999f);
                    else if (!agent.disappeared)
                        e.KnockbackStrength = 80f;
                    if (myAgent.statusEffects.hasTrait("CauseBiggerKnockback"))
                        e.KnockbackStrength *= 2f;
                    // set knockback direction
                    float rot = myMelee.meleeContainerTr.rotation.eulerAngles.z - 90f;
                    e.KnockbackDirection = new Vector2(Mathf.Sin(rot * Mathf.Deg2Rad), Mathf.Cos(rot * Mathf.Deg2Rad));

                    // set noise
                    if (gc.serverPlayer && (myMelee.successfullyBackstabbed || !myMelee.successfullySleepKilled))
                    {
                        e.NoisePosition = me.tr.position;
                        e.NoiseVolume = myMelee.successfullyBackstabbed ? 0.7f : 1f;
                    }

                    // set AI combat cooldown
                    e.AICombatCooldown = myAgent.combat.meleeJustHitTimeStart;
                    e.AICombatCooldownClose = myAgent.combat.meleeJustHitCloseTimeStart;

                    // set screen shake, vibration and AlienFX
                    if (myAgent.isPlayer > 0 && myAgent.localPlayer || agent.isPlayer > 0 && agent.localPlayer)
                    {
                        bool fatalHit = agent.justDied;
                        e.ScreenShakeTime = fatalHit ? 0.25f : 0.2f;
                        e.ScreenShakeOffset = Mathf.Clamp(15 * e.DamageDealt, fatalHit ? 160 : 0, 500);
                    }
                    if (myAgent.isPlayer > 0)
                    {
                        e.VibrateControllerIntensity = Mathf.Clamp(agent.damagedAmount / 100f + 0.05f, 0f, 0.25f);
                        e.VibrateControllerTime = Mathf.Clamp(agent.damagedAmount / 132f + 0.05f, 0f, 0.2f);
                        e.AlienFX = true;
                    }
                    #endregion

                    #region Agent side effects
                    // infect the opponent
                    if (myAgent.zombified && agent.isPlayer == 0 && !agent.oma.bodyGuarded)
                        agent.zombieWhenDead = true;

                    // handle FleshFeast traits
                    if (agent.isPlayer == 0 && myAgent.isPlayer != 0 && !agent.dead && agent.agentName != "Zombie"
                        && !agent.inhuman && !agent.mechEmpty && !agent.mechFilled && myAgent.localPlayer
                        && !agent.statusEffects.hasStatusEffect("Invincible"))
                    {
                        if (myAgent.statusEffects.hasTrait("FleshFeast2"))
                            myAgent.statusEffects.ChangeHealth(6f);
                        else if (myAgent.statusEffects.hasTrait("FleshFeast"))
                            myAgent.statusEffects.ChangeHealth(3f);
                    }

                    // alert attacker's followers to attack
                    myAgent.relationships.FollowerAlert(agent);
                    // handle AttacksDamageAttacker traits
                    if (!myAgent.ghost)
                    {
                        bool upgrade;
                        if ((upgrade = agent.statusEffects.hasTrait("AttacksDamageAttacker2"))
                            || agent.statusEffects.hasTrait("AttacksDamageAttacker"))
                        {
                            if (gc.percentChance(agent.DetermineLuck(20, "AttacksDamageAttacker", true)))
                            {
                                myAgent.lastHitByAgent = agent;
                                myAgent.justHitByAgent2 = agent;
                                myAgent.lastHitByAgent = agent;
                                myAgent.deathMethod = "AttacksDamageAttacker";
                                myAgent.deathKiller = agent.agentName;
                                myAgent.statusEffects.ChangeHealth(upgrade ? -10f : -5f);
                            }
                        }
                    }

                    if (agent.justDied && myAgent.isPlayer > 0 && !gc.coopMode && !gc.fourPlayerMode && !gc.multiplayerMode
                        && gc.sessionDataBig.slowMotionCinematic && gc.percentChance(25))
                    {
                        if (!gc.challenges.Contains("LowHealth") || gc.percentChance(50))
                            gc.StartCoroutine(gc.SetSecondaryTimeScale(0.1f, 0.13f));
                    }

                    // handle ProtectiveShell ability
                    //   with a chance to knock weapons
                    // TODO: I guess there's no need to do this one
                    #endregion

                    if (gc.levelType == "Tutorial") gc.tutorial.MeleeTarget(agent);
                }

                return () =>
                {
                    #region #multiplayer-sync
                    if (!gc.serverPlayer && (myAgent.localPlayer || myAgent.mindControlAgent == gc.playerAgent))
                    {
                        myAgent.objectMultPlayfield.TempDisableNetworkTransform(agent);
                        Quaternion localRotation = myMelee.meleeHelperTr.localRotation;
                        myMelee.meleeHelperTr.rotation = myMelee.meleeContainerTr!.rotation;
                        myMelee.meleeHelperTr.position = myMelee.meleeContainerTr.position;
                        myMelee.meleeHelperTr.localPosition = new Vector3(myMelee.meleeHelperTr.localPosition.x, myMelee.meleeHelperTr.localPosition.y + 10f, myMelee.meleeHelperTr.localPosition.z);
                        Vector3 position2 = myMelee.meleeHelperTr.position;
                        myMelee.meleeHelperTr.localPosition = Vector3.zero;
                        myMelee.meleeHelperTr.localRotation = localRotation;
                        if (!myAgent.testingNewClientLerps)
                        {
                            if (myAgent.isPlayer != 0)
                            {
                                myAgent.objectMult.CallCmdMeleeHitAgent(agent.objectNetID, position2, (int)e.KnockbackStrength,
                                                                        agent.tr.position, agent.rb.velocity);
                            }
                            else
                            {
                                gc.playerAgent.objectMult.CallCmdMeleeHitAgentNPC(myAgent.objectNetID, agent.objectNetID, position2,
                                                                                  (int)e.KnockbackStrength, agent.tr.position, agent.rb.velocity);
                            }
                        }
                    }
                    else if (gc.multiplayerMode && gc.serverPlayer)
                        myAgent.objectMult.CallRpcMeleeHitObjectFake(agent.objectNetID);
                    #endregion
                };
            }
            static Action? HitItem(MeleeHitbox me, Item item, MeleePreHitArgs pre, MeleeHitArgs e)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;
                InvItem weaponItem = myAgent.inventory.equippedWeapon ?? myAgent.inventory.fist;
                if (weaponItem.itemType == ItemTypes.WeaponProjectile)
                    weaponItem = myAgent.inventory.fist;
                CustomWeaponMelee? custom = weaponItem.GetHook<CustomWeaponMelee>();

                #region #multiplayer-sync
                if (!gc.serverPlayer && !myAgent.localPlayer && myAgent.mindControlAgent != gc.playerAgent)
                {
                    me.FakeHit(e.GameObject);
                    return null;
                }
                #endregion

                #region Item pre-conditions
                if (item.justSpilled) return null;
                if (weaponItem!.meleeNoHit) return null;
                if (item.itemObject != null) return null; // part of an object?
                if (!pre.IgnoreLineOfSight && !me.HasLOSMelee(item)) return null;
                #endregion

                item.Damage(myMelee, e.FromClient); // TODO: pre.WeaponDamage
                // trigger item's effects // TODO: e.TriggerItems?
                if (item.invItem.reactOnTouch) item.TouchMe(myAgent, "MeleeHitbox");
                item.thrower = myAgent;
                if (item.go.activeSelf) item.StartCoroutine(item.HitCauserCoroutine(myAgent));

                #region Item hit parameters
                // set knockback strength and direction
                e.KnockbackStrength = !e.FromClient ? 250f : 0f;
                float rot = myMelee.meleeContainerTr.rotation.eulerAngles.z - 90f;
                e.KnockbackDirection = new Vector2(Mathf.Sin(rot * Mathf.Deg2Rad), Mathf.Cos(rot * Mathf.Deg2Rad));

                // set noise and own check
                if (gc.serverPlayer && !myMelee.successfullySleepKilled && !myAgent.statusEffects.hasTrait("HitObjectsNoNoise"))
                {
                    e.NoisePosition = me.tr.position;
                    e.NoiseVolume = 1f;
                }
                e.DoOwnCheck = item.startingOwner != 0 && gc.serverPlayer && !myAgent.statusEffects.hasTrait("NoStealPenalty");
                // set vibration
                e.VibrateControllerIntensity = Mathf.Clamp(myMelee.invItem.meleeDamage / 100f + 0.05f, 0f, 0.25f);
                e.VibrateControllerTime = Mathf.Clamp(myMelee.invItem.meleeDamage / 132f + 0.05f, 0f, 0.2f);
                #endregion

                // prevent hitting yourself with the item
                Physics2D.IgnoreCollision(item.myCollider2D, myAgent.myCollider2D, true);
                Physics2D.IgnoreCollision(item.myCollider2D, myAgent.agentItemCollider, true);

                return () =>
                {
                    #region #multiplayer-sync
                    if (!gc.serverPlayer && (myAgent.localPlayer || myAgent.mindControlAgent == gc.playerAgent))
                    {
                        myAgent.objectMultPlayfield.TempDisableNetworkTransform(item);
                        Quaternion rot1 = myMelee.meleeHelperTr.localRotation;
                        myMelee.meleeHelperTr.rotation = myMelee.meleeContainerTr.rotation;
                        myMelee.meleeHelperTr.position = myMelee.meleeContainerTr.position;
                        Vector3 pos1 = myMelee.meleeHelperTr.localPosition;
                        pos1.y += 10f;
                        myMelee.meleeHelperTr.localPosition = pos1;

                        Vector3 pos2 = myMelee.meleeHelperTr.position;
                        myMelee.meleeHelperTr.localPosition = Vector3.zero;
                        myMelee.meleeHelperTr.localRotation = rot1;

                        if (myAgent.isPlayer != 0)
                        {
                            myAgent.objectMult.CallCmdMeleeHitItem(item.objectNetID, pos2, (int)e.KnockbackStrength,
                                                                   item.tr.position, item.rb.velocity);
                        }
                        else
                        {
                            gc.playerAgent.objectMult.CallCmdMeleeHitItemNPC(myAgent.objectNetID, item.objectNetID, pos2,
                                                                             (int)e.KnockbackStrength, item.tr.position, item.rb.velocity);
                        }
                    }
                    #endregion
                };
            }
            static Action? HitMelee(MeleeHitbox me, Melee melee, MeleePreHitArgs pre, MeleeHitArgs e)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;
                InvItem weaponItem = myAgent.inventory.equippedWeapon ?? myAgent.inventory.fist;
                if (weaponItem.itemType == ItemTypes.WeaponProjectile)
                    weaponItem = myAgent.inventory.fist;
                CustomWeaponMelee? custom = weaponItem.GetHook<CustomWeaponMelee>();

                Agent agent = melee.agent;
                InvItem otherWeapon = agent.inventory.equippedWeapon ?? agent.inventory.fist;
                if (otherWeapon.itemType == ItemTypes.WeaponProjectile)
                    otherWeapon = agent.inventory.fist;

                #region #multiplayer-sync
                if (gc.serverPlayer && myAgent.isPlayer == 0 && agent.isPlayer > 0 && !agent.localPlayer)
                    return null;
                if (!gc.serverPlayer && myAgent.isPlayer == 0 && !agent.localPlayer && myAgent != agent
                    && (agent.mindControlAgent != gc.playerAgent && myAgent.mindControlAgent != gc.playerAgent || agent.dead))
                    return null;
                if (gc.multiplayerMode && gc.serverPlayer && myAgent.isPlayer == 0 && agent.isPlayer == 0
                    && myAgent.mindControlAgent != null && myAgent.mindControlAgent != gc.playerAgent && !agent.dead)
                {
                    me.FakeHit(e.GameObject);
                    return null;
                }
                if (gc.multiplayerMode && gc.serverPlayer && myAgent.isPlayer == 0 && agent.isPlayer == 0
                    && agent.mindControlAgent != null && agent.mindControlAgent != gc.playerAgent && !agent.dead)
                {
                    me.FakeHit(e.GameObject);
                    return null;
                }
                if (!gc.serverPlayer && myAgent.isPlayer > 0 && !myAgent.localPlayer && !agent.localPlayer)
                    return null;
                #endregion

                #region Melee pre-conditions and checks
                // if the weapons don't hit
                if (weaponItem.meleeNoHit || otherWeapon.meleeNoHit) return null;

                if (myAgent == agent) return null; // same?
                if (!pre.IgnoreLineOfSight && !me.HasLOSMelee(melee.agent)) return null;
                if (!pre.IgnoreAlignedCheck && !myAgent.DontHitAlignedCheck(agent)) return null;

                if (!pre.IgnoreSizeDifference)
                {
                    if (myAgent.agentSpriteTransform.localScale.x >= 3f
                        || agent.agentSpriteTransform.localScale.x >= 3f
                        || myAgent.agentSpriteTransform.localScale.x <= 0.34f
                        || agent.agentSpriteTransform.localScale.x <= 0.34f)
                    {
                        return null;
                    }
                }
                #endregion

                // find and clamp damage (e.WeaponDamage)
                // knockback depends on damage?

                // TODO: Clean up
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

                return () => { };
            }
            static Action? HitBullet(MeleeHitbox me, Bullet bullet, MeleePreHitArgs pre, MeleeHitArgs e)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;



                return () => { };
            }
            static Action? HitWall(MeleeHitbox me, MeleePreHitArgs pre, MeleeHitArgs e)
            {
                GameController gc = me.gc;
                Melee myMelee = me.myMelee;
                Agent myAgent = myMelee.agent;

                // TODO
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
                //     set wall's layer to 1 ??? (destroyed walls layer?)

                // TODO: Clean up
                // if (wall destroyed)
                //     play wall destruction sound
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

                return () => { };
            }
        }

        private sealed class MeleeHitHook : HookBase<PlayfieldObject>
        {
            protected override void Initialize() { }

            public bool IsFirstHit(PlayfieldObject obj) => !HitList.Contains(obj);
            public void RegisterHit(PlayfieldObject obj) => HitList.Add(obj);

            public bool CanHitAgain(PlayfieldObject obj) => CanHitAgainList.Remove(obj);
            public void SetCanHitAgain(PlayfieldObject obj) => CanHitAgainList.Add(obj);

            public void Clear()
            {
                HitList.Clear();
                CanHitAgainList.Clear();
            }

            private readonly List<PlayfieldObject> HitList = new List<PlayfieldObject>();
            private readonly List<PlayfieldObject> CanHitAgainList = new List<PlayfieldObject>();

        }

    }
}
