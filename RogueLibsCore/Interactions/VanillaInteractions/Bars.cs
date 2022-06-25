using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Bars()
        {
            PatchInteract<Bars>();

            RogueLibs.CreateCustomName("InteractWithAgent", NameTypes.Interface, new CustomNameInfo
            {
                English = "Interact With NPC",
                Russian = @"Взаимодействовать с НПС",
            });
            RogueInteractions.CreateProvider<Bars>(static h =>
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
                        m.Object.mainGUI.SetInterfaceActive("ObjectButtons", false);
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
