using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
    public abstract class InteractionModel : HookBase<PlayfieldObject>
    {
        protected InteractionModel()
        {
            Interactions = new ReadOnlyCollection<Interaction>(interactions);
        }

        public new PlayfieldObject Instance => base.Instance;
        public PlayfieldObject Object => base.Instance;
        public Agent Agent => base.Instance.interactingAgent;
        public InteractionHelper Helper => base.Instance.interactingAgent.interactionHelper;
        // ReSharper disable once InconsistentNaming
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "That's how it's called in the original code")]
        public GameController gc => GameController.gameController;

        internal bool shouldStop;
        internal bool forcedStop;
        public void StopInteraction() => StopInteraction(false);
        public void StopInteraction(bool forced)
        {
            if (forcedStop) return;
            if (!forced)
            {
                shouldStop = true;
                return;
            }
            shouldStop = false;
            forcedStop = true;
            OriginalStopInteraction(Instance);
        }

        protected override void Initialize() { }

        private readonly List<Interaction> interactions = new List<Interaction>();
        public ReadOnlyCollection<Interaction> Interactions { get; }

        public Action? CancelCallback { get; set; }
        public Action? SideEffect { get; set; }

        public bool RemoveInteraction(Interaction interaction)
            => interactions.Remove(interaction);
        public bool RemoveInteraction(Predicate<Interaction> predicate)
        {
            int index = interactions.FindIndex(predicate);
            if (index is -1) return false;
            interactions.RemoveAt(index);
            return true;
        }
        public bool RemoveInteraction(string buttonName)
            => RemoveInteraction(i => i.ButtonName == buttonName);

        public Coroutine StartOperating(float timeToUnlock, bool makeNoise, string barType)
            => StartOperating((InvItem?)null, timeToUnlock, makeNoise, barType);
        public Coroutine StartOperating(string itemName, float timeToUnlock, bool makeNoise, string barType)
            => StartOperating(Agent.inventory.FindItem(itemName), timeToUnlock, makeNoise, barType);
        public Coroutine StartOperating(InvItem? item, float timeToUnlock, bool makeNoise, string barType)
            => Object.StartCoroutine(Object.Operating(Agent, item, timeToUnlock, makeNoise, barType));

        public void OnDetermineButtons()
        {
            try
            {
                RogueLibsPlugin.useModelStopInteraction = true;
                OnDetermineButtons2();
            }
            finally
            {
                RogueLibsPlugin.useModelStopInteraction = false;
            }
        }
        private void OnDetermineButtons2()
        {
            // reset state
            interactions.Clear();
            shouldStop = false;
            forcedStop = false;
            CancelCallback = null;
            SideEffect = null;

            // repopulate the interactions
            foreach (IInteractionProvider provider in RogueInteractions.Providers)
            {
                try
                {
                    Interaction[] provided = provider.GetInteractions(this).ToArray();
                    for (int i = 0, length = provided.Length; i < length; i++)
                    {
                        Interaction interaction = provided[i];
                        interaction.Model = this;
                        bool success = interaction.SetupButton() && interaction.ButtonName is not null;
                        if (success) interactions.Add(interaction);
                    }
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"Interaction provider {provider} threw an exception while getting interactions for {Object}.");
                    RogueFramework.LogError(e.ToString());
                }
            }
            interactions.Sort();

            // invoke the SideEffect
            SideEffect?.Invoke();

            // if there are no buttons, or one of them cancelled the entire interaction
            if (interactions.Count is 0 || shouldStop)
            {
                CancelCallback?.Invoke(); // TODO: try-catch
                OriginalStopInteraction(Instance);
                return;
            }
            if (forcedStop) return;
            // if there's only one button and its action is implicit
            if (interactions.Count is 1 && interactions[0].ImplicitAction) // TODO: try-catch
            {
                interactions[0].OnPressedImplicitly(); // TODO: try-catch
                if (IsControlIntercepted()) return;
                OriginalStopInteraction(Instance);
                return;
            }

            // add button information to the object
            foreach (Interaction interaction in interactions)
            {
                Instance.buttons.Add(interaction.ButtonName);
                Instance.buttonPrices.Add(interaction.ButtonPrice ?? 0);
                Instance.buttonsExtra.Add(interaction.ButtonExtra ?? string.Empty);
            }

        }
        public void OnPressedButton(string buttonName)
        {
            try
            {
                RogueLibsPlugin.useModelStopInteraction = true;
                OnPressedButton2(buttonName);
            }
            finally
            {
                RogueLibsPlugin.useModelStopInteraction = false;
            }
        }
        private void OnPressedButton2(string buttonName)
        {
            // reset state
            shouldStop = false;
            forcedStop = false;
            CancelCallback = null;

            // handle the default "Done" button
            if (buttonName is "Done")
            {
                OriginalStopInteraction(Instance);
                return;
            }
            // find the button that was pressed
            Interaction pressed = interactions.Find(i => i.ButtonName == buttonName);
            if (pressed is null)
            {
                RogueFramework.LogError($"Couldn't find '{buttonName}' button on {Object}.");
                RogueFramework.LogDebug($"Available: {string.Join(",", interactions.ConvertAll(static i => i.ButtonName))}.");
                return;
            }
            // press the button
            pressed.OnPressed(); // TODO: try-catch
            // if the button's action is 'final' or was unsuccessful
            if (shouldStop)
            {
                CancelCallback?.Invoke(); // TODO: try-catch
                OriginalStopInteraction(Instance);
                return;
            }
            if (IsControlIntercepted()) return;

            // refresh the buttons (restarts the cycle)
            Agent.worldSpaceGUI?.StartCoroutine(Agent.worldSpaceGUI.RefreshObjectButtons2(Object));
        }

        public bool IsControlIntercepted()
        {
            if (forcedStop || Instance.interactingAgent is null) return true;

            WorldSpaceGUI? ws = Agent.worldSpaceGUI;
            if (ws is not null)
            {
                if (ws.openedUseOn || ws.openedChest || ws.openedChest2 || ws.openedNPCChest) return true;
            }

            MainGUI? gui = Agent.mainGUI;
            if (gui is not null)
            {
                if (gui.showingTarget || gui.openedOperatingBar || gui.openedInventory || gui.openedCharacterSheet
                    || gui.openedQuestSheet || gui.openedBigImage || gui.openedSetSeed || gui.openedBigMessage
                    || gui.openedCharacterSelect || gui.openedScrollingMenu || gui.openedScrollingMenuPersonal
                    || gui.openedCharacterCreation) return true;
            }
            return false;
        }

        private static void OriginalStopInteraction(PlayfieldObject obj)
        {
            RogueLibsPlugin.useModelStopInteraction = false;
            obj.StopInteraction();
        }

    }
    public class InteractionModel<T> : InteractionModel where T : PlayfieldObject
    {
        public new T Instance => (T)base.Instance;
        public new T Object => (T)base.Instance;
    }
}
