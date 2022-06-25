using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

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
            if (!fakingInteraction) OriginalStopInteraction(Instance);
        }

        protected override void Initialize() { }

        private readonly List<Interaction> interactions = new List<Interaction>();
        public ReadOnlyCollection<Interaction> Interactions { get; }

        public Action? StopCallback { get; set; }
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

        public bool HasInteraction(Interaction interaction)
            => interactions.Contains(interaction);
        public bool HasInteraction(Predicate<Interaction> interaction)
            => interactions.Exists(interaction);
        public bool HasInteraction(string buttonName)
            => interactions.Exists(i => i.ButtonName == buttonName);

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
            StopCallback = null;
            SideEffect = null;

            // repopulate the interactions
            IInteractionProvider? lastProvider = null;
            try
            {
                for (int i = 0, count = RogueInteractions.Providers.Count; i < count; i++)
                {
                    IInteractionProvider provider = RogueInteractions.Providers[i];
                    Interaction[] provided = provider.GetInteractions(this);
                    for (int j = 0, length = provided.Length; j < length; j++)
                    {
                        Interaction interaction = provided[j];
                        interaction.Model = this;
                        bool success = interaction.SetupButton() && interaction.ButtonName is not null;
                        if (success) interactions.Add(interaction);
                    }
                }
            }
            catch (Exception e)
            {
                RogueFramework.LogError($"Interaction provider {lastProvider} threw an exception while getting interactions for {Object}.");
                RogueFramework.LogError(e.ToString());
            }

            interactions.Sort();

            // invoke the SideEffect
            SideEffect?.Invoke();

            // if there are no buttons, or one of them cancelled the entire interaction
            if (interactions.Count is 0 || shouldStop || forcedStop)
            {
                StopCallback?.Invoke(); // TODO: try-catch
                if (!forcedStop)
                    OriginalStopInteraction(Instance);
                return;
            }
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
            StopCallback = null;

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
                StopCallback?.Invoke(); // TODO: try-catch
                OriginalStopInteraction(Instance);
                return;
            }
            if (IsControlIntercepted()) return;

            // refresh the buttons (restarts the cycle)
            Agent.worldSpaceGUI?.StartCoroutine(Agent.worldSpaceGUI.RefreshObjectButtons2(Object));
        }

        private bool fakingInteraction;
        public bool IsInteractable(Agent agent)
        {
            Agent? prevAgent = Instance.interactingAgent;
            try
            {
                fakingInteraction = true;
                RogueLibsPlugin.useModelStopInteraction = true;
                Instance.interactingAgent = agent;
                return IsInteractable2();
            }
            finally
            {
                fakingInteraction = false;
                RogueLibsPlugin.useModelStopInteraction = false;
                Instance.interactingAgent = prevAgent;
            }
        }
        private bool IsInteractable2()
        {
            // reset state
            interactions.Clear();
            shouldStop = false;
            forcedStop = false;
            StopCallback = null;
            SideEffect = null;

            // repopulate the interactions
            IInteractionProvider? lastProvider = null;
            try
            {
                for (int i = 0, count = RogueInteractions.Providers.Count; i < count; i++)
                {
                    IInteractionProvider provider = RogueInteractions.Providers[i];
                    Interaction[] provided = provider.GetInteractions(this);
                    for (int j = 0, length = provided.Length; j < length; j++)
                    {
                        Interaction interaction = provided[j];
                        interaction.Model = this;
                        bool success = interaction.SetupButton() && interaction.ButtonName is not null;
                        if (success) interactions.Add(interaction);
                    }
                }
            }
            catch (Exception e)
            {
                RogueFramework.LogError($"Interaction provider {lastProvider} threw an exception while getting interactions for {Object}.");
                RogueFramework.LogError(e.ToString());
            }

            return interactions.Count > 0 || StopCallback is not null || SideEffect is not null;
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
            try
            {
                RogueLibsPlugin.useModelStopInteraction = false;
                obj.StopInteraction();
            }
            finally
            {
                RogueLibsPlugin.useModelStopInteraction = true;
            }
        }

    }
    public class InteractionModel<T> : InteractionModel where T : PlayfieldObject
    {
        public new T Instance => (T)base.Instance;
        public new T Object => (T)base.Instance;
    }
}
