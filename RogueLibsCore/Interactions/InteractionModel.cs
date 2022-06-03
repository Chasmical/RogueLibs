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
        public void StopInteraction() => shouldStop = true;

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
            // reset state
            interactions.Clear();
            shouldStop = false;
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
                Instance.StopInteraction();
                return;
            }
            // if there's only one button and its action is implicit
            if (interactions.Count is 1 && interactions[0].ImplicitAction) // TODO: try-catch
            {
                interactions[0].OnPressedImplicitly(); // TODO: try-catch
                // if the interaction opened some kind of menu, stop here (presumably, object buttons are hidden)
                if (Instance.interactingAgent is null
                    || Agent.worldSpaceGUI?.openedUseOn is true
                    || Agent.worldSpaceGUI?.openedChest is true
                    || Agent.worldSpaceGUI?.openedChest2 is true
                    || Agent.worldSpaceGUI?.openedNPCChest is true
                    || Agent.mainGUI?.showingTarget is true
                    || Agent.mainGUI?.openedOperatingBar is true
                    || Agent.mainGUI?.openedBigImage is true
                    || Agent.mainGUI?.openedScrollingMenu is true
                    || Agent.mainGUI?.openedScrollingMenuPersonal is true) return;
                Instance.StopInteraction();
                return;
            }

            // add button information to the object
            foreach (Interaction interaction in interactions)
            {
                Instance.buttons.Add(interaction.ButtonName);
                Instance.buttonPrices.Add(interaction.ButtonPrice ?? 0);
                Instance.buttonsExtra.Add(interaction.ButtonExtra ?? string.Empty);
            }

            // invoke OnOpen method, because right after this, a menu will show up.
            // TODO: maybe we should rely on ShowObjectButtons() explicitly instead of this assumption
            interactions.ForEach(static i => i.OnOpen()); // TODO: try-catch

        }
        public void OnPressedButton(string buttonName)
        {
            // reset state
            shouldStop = false;
            CancelCallback = null;

            // handle the default "Done" button
            if (buttonName is "Done")
            {
                Instance.StopInteraction();
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
                Instance.StopInteraction();
                return;
            }

            // if the interaction opened some kind of menu, stop here (presumably, object buttons are hidden)
            if (Instance.interactingAgent is null
                || Agent.worldSpaceGUI?.openedUseOn is true
                || Agent.worldSpaceGUI?.openedChest is true
                || Agent.worldSpaceGUI?.openedChest2 is true
                || Agent.worldSpaceGUI?.openedNPCChest is true
                || Agent.mainGUI?.showingTarget is true
                || Agent.mainGUI?.openedOperatingBar is true
                || Agent.mainGUI?.openedBigImage is true
                || Agent.mainGUI?.openedScrollingMenu is true
                || Agent.mainGUI?.openedScrollingMenuPersonal is true) return;

            // refresh the buttons (restarts the cycle)
            Agent.worldSpaceGUI?.StartCoroutine(Agent.worldSpaceGUI.RefreshObjectButtons2(Object));
        }

    }
    public class InteractionModel<T> : InteractionModel where T : PlayfieldObject
    {
        public new T Instance => (T)base.Instance;
        public new T Object => (T)base.Instance;
    }
}
