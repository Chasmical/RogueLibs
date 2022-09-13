using System.Collections.Generic;

namespace RogueLibsCore.Test
{
    public class MaxTraits : MutatorUnlock
    {
        public MaxTraits() : base(nameof(MaxTraits)) { UnlockCost = 3; }

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomUnlock(new MaxTraits())
                     .WithName(new CustomNameInfo("Max Traits"))
                     .WithDescription(new CustomNameInfo("Everyone gets their traits upgraded!"));

            RoguePatcher patcher = new RoguePatcher(TestPlugin.Instance) { TypeWithPatches = typeof(MaxTraits) };
            patcher.Postfix(typeof(Agent), nameof(Agent.SetupAgentStats));
        }

        public static void Agent_SetupAgentStats(Agent __instance)
        {
            if (!gc.challenges.Contains(nameof(MaxTraits))) return;

            List<Trait> upgradeable = __instance.statusEffects.TraitList.FindAll(static trait =>
            {
                UnlockWrapper? unlock = RogueFramework.Unlocks.Find(u => u.Type == UnlockTypes.Trait && u.Name == trait.traitName);
                return !string.IsNullOrEmpty(unlock?.Unlock.upgrade);
            });
            if (upgradeable.Count > 0)
            {
                __instance.usingAugmentationBooth = true;
                upgradeable.ForEach(trait =>
                {
                    UnlockWrapper unlock = RogueFramework.Unlocks.Find(u => u.Type == UnlockTypes.Trait && u.Name == trait.traitName);
                    __instance.statusEffects.AddTrait(unlock.Unlock.upgrade);
                });
                __instance.usingAugmentationBooth = false;
            }
        }



    }
}
