using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Agent()
        {
            Patch<Agent>(Params2);
            PatchInteractFar<Agent>();
            // See Agent.Interact patch and other patches in Patches_AgentInteractions.cs

            RogueInteractions.CreateProvider<Agent>(static h =>
            {
                try
                {
                    Agent agent = h.Object;
                    Agent interactingAgent = h.Agent;
                    try
                    {
                        Queuing = true; // call the original method with a flag
                        agent.agentInteractions.DetermineButtons(agent, interactingAgent, agent.buttons, agent.buttonsExtra, agent.buttonPrices);
                    }
                    finally
                    {
                        Queuing = false;
                    }

                    if (preparedButtons.Count is 0) // no buttons, any actions are a part of a stop callback
                    {
                        if (queuedActions.Count is 0) return; // no actions, no stop callback

                        QueuedAction[] stopCallback = queuedActions.ToArray();
                        h.SetStopCallback(m =>
                        {
                            for (int i = 0, length = stopCallback.Length; i < length; i++)
                                stopCallback[i].Action(m);
                        });
                    }
                    else // there are buttons, create an action for each one
                    {
                        for (int i = 0, length = preparedButtons.Count; i < length; i++)
                        {
                            PreparedButton button = preparedButtons[i];
                            h.AddButton(button.ButtonName, button.ButtonPrice, button.ButtonExtra, m =>
                            {
                                m.Object.agentInteractions.PressedButton(m.Object, m.Agent, button.ButtonName, button.ButtonPrice);
                            });
                        }
                    }
                }
                finally // clean up, prepare fields for the next interaction
                {
                    queuedActions.Clear();
                    preparedButtons.Clear();
                }
            });

        }

        private readonly struct QueuedAction
        {
            public QueuedAction(string id, Action<InteractionModel<Agent>> action)
            {
                Id = id;
                Action = action;
            }
            public readonly string Id;
            public readonly Action<InteractionModel<Agent>> Action;
        }
        private readonly struct PreparedButton
        {
            public PreparedButton(string buttonName, int buttonPrice, string? buttonExtra)
            {
                ButtonName = buttonName;
                ButtonPrice = buttonPrice;
                ButtonExtra = buttonExtra;
            }
            public readonly string ButtonName;
            public readonly int ButtonPrice;
            public readonly string? ButtonExtra;
        }

        public static bool Queuing { get; private set; }
        private static readonly Queue<QueuedAction> queuedActions = new Queue<QueuedAction>();
        private static readonly List<PreparedButton> preparedButtons = new List<PreparedButton>();

        public static void QueueAction(string id, Action<InteractionModel<Agent>> action)
            => queuedActions.Enqueue(new QueuedAction(id, action));
        public static void PrepareButton(string name, int price, string? buttonExtra)
            => preparedButtons.Add(new PreparedButton(name, price, buttonExtra));

    }
}
