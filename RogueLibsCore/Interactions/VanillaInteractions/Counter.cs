using UnityEngine;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Counter()
        {
            PatchInteract<Bars>();

            // See "InteractWithAgent" in Bars.cs
            RogueInteractions.CreateProvider<Bars>(static h =>
            {
                if (h.Helper.interactingFar) return;

                if (h.Object.counterAgent is not null
                    && Vector2.Distance(h.Object.tr.position, h.Object.counterAgent.tr.position) < 0.84f)
                {
                    h.AddImplicitButton("InteractWithAgent", static m =>
                    {
                        Agent agent = m.Agent;
                        InteractionHelper helper = m.Helper;
                        Agent counterAgent = m.Object.counterAgent;
                        m.Object.StopInteraction();

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
