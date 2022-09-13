using System.Collections;

namespace RogueLibsCore.Test
{
    public class NewHealthOrder : CustomDisaster
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomDisaster<NewHealthOrder>()
                     .WithName(new CustomNameInfo
                     {
                         English = "New Health Order",
                     })
                     .WithDescription(new CustomNameInfo
                     {
                         English = "Where is this line used?!",
                     })
                     .WithMessage(new CustomNameInfo
                     {
                         English = "N.H.O. - New Health Order",
                     })
                     .WithMessage(new CustomNameInfo
                     {
                         English = "Resurrection for everyone!",
                     })
                     .WithRemovalMutator();
        }

        public override void Start() { }
        public override void Finish() { }

        public override IEnumerator Updating()
        {
            foreach (Agent agent in gc.agentList)
                if (!agent.dead && !agent.electronic && !agent.inhuman)
                {
                    agent.statusEffects.AddStatusEffect(VanillaEffects.Resurrection, false);
                }
            yield break;
        }
    }
}
