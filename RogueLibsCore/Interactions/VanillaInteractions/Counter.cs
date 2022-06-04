using UnityEngine;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Counter()
        {
            PatchInteract<Counter>();

            // See "InteractWithAgent" in Bars.cs
            RogueInteractions.CreateProvider<Counter>(static h =>
            {
                if (h.Helper.interactingFar) return;

                if (h.Object.counterAgent is not null
                    && Vector2.Distance(h.Object.tr.position, h.Object.counterAgent.tr.position) < 0.84f)
                {
                    h.AddImplicitButton("InteractWithAgent", static m =>
                    {
                        Agent agent = m.Agent;
                        Agent counterAgent = m.Object.counterAgent;
                        m.StopInteraction(true);
                        InteractionHelper helper = agent.interactionHelper;

                        if (helper.CanInteractWithAgent(counterAgent))
                        {
                            helper.interactionObject = counterAgent.objectSprite.gameObject;
                            helper.interactingFar = true;
                            helper.interactingCounter = true;
                            helper.clientInteracting = true;
                            counterAgent.Interact(agent);
                        }
                    });
                }
            });
        }
    }
}
