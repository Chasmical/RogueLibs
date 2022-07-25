using System;
using System.Reflection;
using JetBrains.Annotations;

namespace RogueLibsCore
{
    internal static partial class VanillaInteractions
    {
        private static RoguePatcher patcher = null!;

        internal static void PatchAll()
        {
            patcher = RogueLibsPlugin.Instance.Patcher;

            Patch<PlayfieldObject>(Params2);
            PatchInteract<PlayfieldObject>();
            PatchInteractFar<PlayfieldObject>();

            object[] empty = Array.Empty<object>();
            foreach (MethodInfo method in typeof(VanillaInteractions).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
            {
                if (method.GetCustomAttribute<IncludeAttribute>() is not null)
                    method.Invoke(null, empty);
            }

            RogueInteractions.CreateProvider(static h =>
            {
                if (!h.Helper.interactingFar) return;
                PlayfieldObject obj = h.Object;
                if (obj is AlarmButton or AmmoDispenser or AugmentationBooth or ArcadeGame or ATMMachine or CloneMachine
                    or Door { placedDetonatorInitial: 1 } or PawnShopMachine or Refrigerator or SlotMachine or Turret
                    or Turntables or SecurityCam or SatelliteDish or PowerBox or Jukebox or Computer or CapsuleMachine)
                {
                    if (h.Agent.oma.superSpecialAbility && h.Agent.agentName == "Hacker"
                        || h.Agent.statusEffects.hasTrait("HacksBlowUpObjects"))
                    {
                        h.AddButton("HackExplode", static m => (m.Object as ObjectReal)?.HackExplode(m.Agent));
                    }
                }
            });
            RogueInteractions.CreateProvider(static h =>
            {
                if (h.Helper.interactingFar) return;
                if (h.Object is ObjectReal objReal && objReal.CanCollectAlienPart())
                {
                    if (objReal is AmmoDispenser or ATMMachine or AugmentationBooth
                        or CapsuleMachine or CloneMachine or LoadoutMachine or PawnShopMachine)
                    {
                        h.AddButton("CollectPart", static m =>
                        {
                            m.StartOperating(5f, true, "Collecting");
                            if (!m.Agent.statusEffects.hasTrait("OperateSecretly") && m.Object.functional)
                            {
                                m.gc.spawnerMain.SpawnNoise(m.Object.tr.position, 1f, m.Agent, "Normal", m.Agent);
                                m.gc.audioHandler.Play(m.Object, "Hack");
                                (m.Object as ObjectReal)?.SpawnParticleEffect("Hack", m.Object.tr.position);
                                m.gc.spawnerMain.SpawnStateIndicator(m.Object, "HighVolume");
                                m.gc.OwnCheck(m.Agent, m.Object.go, "Normal", 0);
                            }
                        });
                    }
                }
            });
        }

        [Include]
        private static void Debug()
        {
            RogueInteractions.CreateProvider(static h =>
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.EnableHints))
                    h.AddButton("InteractionsPatched", static m => m.StopInteraction());
            });
            RogueLibs.CreateCustomName("InteractionsPatched", NameTypes.Interface, new CustomNameInfo
            {
                English = "I am patched!",
                Russian = @"Я пропатчен!",
            });
        }

        private static readonly Type[] Params1 = { typeof(string) };
        private static readonly Type[] Params2 = { typeof(string), typeof(int) };
        internal static void Patch<T>(Type[] parameterTypes) where T : PlayfieldObject
        {
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.DetermineButtons), nameof(RogueLibsPlugin.DetermineButtonsHook));
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.PressedButton), nameof(RogueLibsPlugin.PressedButtonHook), parameterTypes);
        }
        internal static void PatchInteract<T>() where T : PlayfieldObject
        {
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.Interact), nameof(RogueLibsPlugin.InteractHook));
        }
        internal static void PatchInteractFar<T>() where T : PlayfieldObject
        {
            patcher.Prefix(typeof(T), nameof(PlayfieldObject.InteractFar), nameof(RogueLibsPlugin.InteractFarHook));
        }

        [AttributeUsage(AttributeTargets.Method), MeansImplicitUse]
        internal class IncludeAttribute : Attribute { }

    }
}
