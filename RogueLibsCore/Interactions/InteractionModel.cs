﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RogueLibsCore
{
    public abstract class InteractionModel : HookBase<PlayfieldObject>
    {
        protected InteractionModel() => Interactions = new ReadOnlyCollection<Interaction>(interactions);

        public new PlayfieldObject Instance => base.Instance;
        public PlayfieldObject Object => base.Instance;
        public Agent Agent => base.Instance.interactingAgent;
        public InteractionHelper Helper => base.Instance.interactingAgent?.interactionHelper;
        // ReSharper disable once InconsistentNaming
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "That's how it's called in the original code")]
        public GameController gc => GameController.gameController;

        internal bool shouldStop;
        public void StopInteraction() => shouldStop = true;
        public Action CancelCallback { get; set; }

        protected override void Initialize() { }

        private readonly List<Interaction> interactions = new List<Interaction>();
        public ReadOnlyCollection<Interaction> Interactions { get; }

        public void OnDetermineButtons()
        {
			// reset state
            interactions.Clear();
            shouldStop = false;
            CancelCallback = null;

			// repopulate the interactions
            foreach (IInteractionProvider provider in RogueInteractions.Providers)
            {
                try
                {
                    interactions.AddRange(provider.GetInteractions(this).ToArray());
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"Interaction provider {provider} threw an exception while getting interactions for {Object}.");
                    RogueFramework.LogError(e.ToString());
                }
            }
			// set interactions' Model property
            interactions.ForEach(i => i.Model = this);

			// remove those that couldn't set up // TODO: try-catch
            interactions.RemoveAll(i => !i.SetupButton() || i.ButtonName is null);

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
            interactions.ForEach(i => i.OnOpen()); // TODO: try-catch

        }
        public void OnPressedButton(string buttonName)
        {
			// reset state
            shouldStop = false;
            CancelCallback = null;

            // handle the default "Done" button
            if (buttonName == "Done")
            {
                Instance.StopInteraction();
                return;
            }
			// find the button that was pressed
            Interaction pressed = interactions.Find(i => i.ButtonName == buttonName);
            if (pressed is null)
            {
                RogueFramework.LogError($"Couldn't find '{buttonName}' button on {Object}.");
                RogueFramework.LogDebug($"Available: {string.Join(",", interactions.Select(i => i.ButtonName))}.");
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

			// TODO: re-render the menu; this might be really complicated

        }

    }
    public class InteractionModel<T> : InteractionModel where T : PlayfieldObject
    {
        public new T Instance => (T)base.Instance;
        public new T Object => (T)base.Instance;
    }
}