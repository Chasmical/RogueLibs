using System;
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
            Patcher.Postfix(typeof(MeleeContainer), nameof(MeleeContainer.stopMeleeAnim));

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

                    __instance.meleeContainerAnim.speed = anim.Speed;

                    MeleeHands hands = info.Hands;
                    __instance.realArm1.enabled = (hands & MeleeHands.Left) is 0;
                    __instance.realArm2.enabled = (hands & MeleeHands.Right) is 0;
                    __instance.twoHandSwing = (hands & MeleeHands.Both) == MeleeHands.Both;
                    if (anim.Sound is not null)
                        __instance.gc.audioHandler.Play(__instance.agent, anim.Sound);

                    __instance.SetWeaponCooldown(info.Cooldown);
                    __instance.canMove = info.CanMoveDuringAttack;
                    __instance.agent.movement.KnockForward(__instance.agent.tr.rotation, info.KnockForce, true);

                    __instance.meleeHitbox.boxColliderDefaultOffsetX = info.HitBox.x;
                    __instance.meleeHitbox.boxColliderDefaultOffsetY = info.HitBox.y;
                    __instance.meleeHitbox.boxColliderDefaultSizeX = info.HitBox.width;
                    __instance.meleeHitbox.boxColliderDefaultSizeY = info.HitBox.height;

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

        public static void MeleeContainer_stopMeleeAnim(MeleeContainer __instance)
        {
            CustomWeaponMelee? custom = __instance.melee.agent.inventory.equippedWeapon?.GetHook<CustomWeaponMelee>();
            custom?.EndAttack();
        }

    }
}
