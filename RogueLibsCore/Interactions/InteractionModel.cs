using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an object in terms of interactivity and handles its interactions.</para>
    /// </summary>
    public abstract class InteractionModel : HookBase<PlayfieldObject>
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="InteractionModel"/> class.</para>
        /// </summary>
        protected InteractionModel() => Interactions = new ReadOnlyCollection<Interaction>(interactions);

        /// <summary>
        ///   <para>Gets the object that the interaction model is attached to.</para>
        /// </summary>
        public new PlayfieldObject Instance => base.Instance;
        /// <summary>
        ///   <para>Gets the object that the interaction model is attached to.</para>
        /// </summary>
        public PlayfieldObject Object => base.Instance;
        /// <summary>
        ///   <para>Gets the agent that is currently interacting with the object.</para>
        /// </summary>
        public Agent Agent => base.Instance.interactingAgent!;
        /// <summary>
        ///   <para>Gets the <see cref="InteractionHelper"/> of the current interaction.</para>
        /// </summary>
        public InteractionHelper Helper => base.Instance.interactingAgent.interactionHelper!;

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once MemberCanBeMadeStatic.Global
        public GameController gc => GameController.gameController;

        internal bool initialInteract;
        internal bool shouldStop;
        internal bool forcedStop;
        /// <summary>
        ///   <para>Stops the current interaction completely.</para>
        /// </summary>
        public void StopInteraction() => StopInteraction(false);
        /// <summary>
        ///   <para>Stops the current interaction completely. If <paramref name="forced"/> is <see langword="true"/>, forces the model to end the interaction right now, instead of postponing it to after the interaction handlers are processed.</para>
        /// </summary>
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

        /// <inheritdoc/>
        protected override void Initialize() { }

        private readonly List<Interaction> interactions = new List<Interaction>();
        /// <summary>
        ///   <para>Gets the read-only collection of interactions currently initialized.</para>
        /// </summary>
        public ReadOnlyCollection<Interaction> Interactions { get; }

        /// <summary>
        ///   <para>Gets or sets the stop callback, that gets called if the interaction fails, is stopped or is interrupted.</para>
        /// </summary>
        public Action? StopCallback { get; set; }
        /// <summary>
        ///   <para>Gets or sets the side effect, that gets called after the interactions are set up, regardless of whether it was successful.</para>
        /// </summary>
        public Action? SideEffect { get; set; }

        /// <summary>
        ///   <para>Removes the specified <paramref name="interaction"/> from the model.</para>
        /// </summary>
        /// <param name="interaction">The interaction to remove.</param>
        /// <returns><see langword="true"/>, if the interaction was removed successfully; otherwise, <see langword="false"/>.</returns>
        public bool RemoveInteraction(Interaction interaction)
            => interactions.Remove(interaction);
        /// <summary>
        ///   <para>Removes an interaction that satisfies the specified <paramref name="predicate"/> from the model.</para>
        /// </summary>
        /// <param name="predicate">The predicate that matches the interaction to remove.</param>
        /// <returns><see langword="true"/>, if the interaction was removed successfully; otherwise, <see langword="false"/>.</returns>
        public bool RemoveInteraction(Predicate<Interaction> predicate)
        {
            int index = interactions.FindIndex(predicate);
            if (index is -1) return false;
            interactions.RemoveAt(index);
            return true;
        }
        /// <summary>
        ///   <para>Removes an interaction with the specified <paramref name="buttonName"/> from the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction to remove.</param>
        /// <returns><see langword="true"/>, if the interaction was removed successfully; otherwise, <see langword="false"/>.</returns>
        public bool RemoveInteraction(string buttonName)
            => RemoveInteraction(i => i.ButtonName == buttonName);

        /// <summary>
        ///   <para>Determines whether there's a specified <paramref name="interaction"/> in the model.</para>
        /// </summary>
        /// <param name="interaction">The interaction to look for in the model.</param>
        /// <returns><see langword="true"/>, if the specified <paramref name="interaction"/> exists in the model; otherwise, <see langword="false"/>.</returns>
        public bool HasInteraction(Interaction interaction)
            => interactions.Contains(interaction);
        /// <summary>
        ///   <para>Determines whether there is an interaction that satisfies the specified <paramref name="predicate"/> in the model.</para>
        /// </summary>
        /// <param name="predicate">The predicate that matches the interaction to look for.</param>
        /// <returns><see langword="true"/>, if an interaction that satisfies the specified <paramref name="predicate"/> exists in the model; otherwise, <see langword="false"/>.</returns>
        public bool HasInteraction(Predicate<Interaction> predicate)
            => interactions.Exists(predicate);
        /// <summary>
        ///   <para>Determines whether there is an interaction with the specified <paramref name="buttonName"/> in the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction to look for.</param>
        /// <returns><see langword="true"/>, if an interaction with the specified <paramref name="buttonName"/> exists in the model; otherwise, <see langword="false"/>.</returns>
        public bool HasInteraction(string buttonName)
            => interactions.Exists(i => i.ButtonName == buttonName);

        /// <summary>
        ///   <para>Makes the current interacting agent to start operating on the object with the specified parameters.</para>
        /// </summary>
        /// <param name="timeToOperate">The amount of time it takes to finish the operation.</param>
        /// <param name="makeNoise">Determines whether the operation makes noise.</param>
        /// <param name="barType">The type of the operating bar.</param>
        /// <returns>The <see cref="Coroutine"/> representing the operation.</returns>
        public Coroutine StartOperating(float timeToOperate, bool makeNoise, string barType)
            => StartOperating((InvItem?)null, timeToOperate, makeNoise, barType);
        /// <summary>
        ///   <para>Makes the current interacting agent to start operating on the object using an item with the specified <paramref name="itemName"/> with the specified parameters.</para>
        /// </summary>
        /// <param name="itemName">The name of the item to operate with.</param>
        /// <param name="timeToOperate">The amount of time it takes to finish the operation.</param>
        /// <param name="makeNoise">Determines whether the operation makes noise.</param>
        /// <param name="barType">The type of the operating bar.</param>
        /// <returns>The <see cref="Coroutine"/> representing the operation.</returns>
        public Coroutine StartOperating(string itemName, float timeToOperate, bool makeNoise, string barType)
            => StartOperating(Agent.inventory.FindItem(itemName), timeToOperate, makeNoise, barType);
        /// <summary>
        ///   <para>Makes the current interacting agent to start operating on the object using the specified <paramref name="item"/> with the specified parameters.</para>
        /// </summary>
        /// <param name="item">The item to operate with.</param>
        /// <param name="timeToOperate">The amount of time it takes to finish the operation.</param>
        /// <param name="makeNoise">Determines whether the operation makes noise.</param>
        /// <param name="barType">The type of the operating bar.</param>
        /// <returns>The <see cref="Coroutine"/> representing the operation.</returns>
        public Coroutine StartOperating(InvItem? item, float timeToOperate, bool makeNoise, string barType)
            => Object.StartCoroutine(Object.Operating(Agent, item, timeToOperate, makeNoise, barType));

        internal void OnDetermineButtons()
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
            if (interactions.Count is 1 && interactions[0].ImplicitAction && initialInteract) // TODO: try-catch
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
        internal void OnPressedButton(string buttonName)
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
            if (shouldStop || forcedStop)
            {
                StopCallback?.Invoke(); // TODO: try-catch
                if (!forcedStop)
                    OriginalStopInteraction(Instance);
                return;
            }
            if (IsControlIntercepted()) return;

            initialInteract = false; // make subsequent interaction ignore the implicit button
            // refresh the buttons (restarts the cycle)
            Agent.worldSpaceGUI?.RefreshObjectButtons(Object);
        }

        private bool fakingInteraction;
        private bool lastCheckedInteractable;
        private float lastCheckedInteractableAt;
        /// <summary>
        ///   <para>Determines whether the current object can be interacted by the specified <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The agent to determine whether the object is interactable to.</param>
        /// <returns><see langword="true"/>, if the current object is interactable; otherwise, <see langword="false"/>.</returns>
        public bool IsInteractable(Agent agent)
            => IsInteractable(agent, true);
        /// <summary>
        ///   <para>Determines whether the current object can be interacted by the specified <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The agent to determine whether the object is interactable to.</param>
        /// <param name="canUseCachedResult">Determines whether a cached result from less than 0.1s before can be used.</param>
        /// <returns><see langword="true"/>, if the current object is interactable; otherwise, <see langword="false"/>.</returns>
        public bool IsInteractable(Agent agent, bool canUseCachedResult)
        {
            if (canUseCachedResult && Time.unscaledTime - lastCheckedInteractableAt < 0.1f) return lastCheckedInteractable;

            Agent? prevAgent = Instance.interactingAgent;
            try
            {
                fakingInteraction = true;
                RogueLibsPlugin.useModelStopInteraction = true;
                Instance.interactingAgent = agent;
                bool res = IsInteractable2();
                lastCheckedInteractable = res;
                return res;
            }
            catch
            {
                lastCheckedInteractable = false;
                throw;
            }
            finally
            {
                fakingInteraction = false;
                lastCheckedInteractableAt = Time.unscaledTime;
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

        private bool IsControlIntercepted()
        {
            if (forcedStop || Object.interactingAgent is null) return true;

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
    /// <typeparam name="T">The type of the object that the model represents.</typeparam>
    /// <inheritdoc/>
    public class InteractionModel<T> : InteractionModel where T : PlayfieldObject
    {
        /// <summary>
        ///   <para>Gets the object that the interaction model is attached to.</para>
        /// </summary>
        public new T Instance => (T)base.Instance;
        /// <summary>
        ///   <para>Gets the object that the interaction model is attached to.</para>
        /// </summary>
        public new T Object => (T)base.Instance;
    }
}
