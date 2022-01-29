using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Scripting;

namespace RogueLibsCore
{
    public static class RogueInteractions
    {
        public static readonly List<IInteractionFactory> Factories = new List<IInteractionFactory>();
    }
    public class InteractionModel : HookBase<PlayfieldObject>
    {
        public InteractionModel() => Interactions = new ReadOnlyCollection<Interaction>(interactions);

        public PlayfieldObject Object => base.Instance;
        public new PlayfieldObject Instance => base.Instance;
        public Agent Agent => base.Instance.interactingAgent;
        public InteractionHelper Helper => base.Instance.interactingAgent?.interactionHelper;

        internal readonly List<Interaction> interactions = new List<Interaction>();
        public ReadOnlyCollection<Interaction> Interactions { get; }

        internal readonly List<Func<Interaction, bool>> preventPredicates = new List<Func<Interaction, bool>>();

        internal bool shouldStopInteracting;
        public Action CancelCallback { get; set; }

        protected override void Initialize() { }

        public void OnDetermineButtons()
        {
            shouldStopInteracting = false;
            CancelCallback = null;

            interactions.Clear();
            preventPredicates.Clear();
            // this will act as a replacement for the PlayfieldObject.DetermineButtons() method
            foreach (IInteractionFactory factory in RogueInteractions.Factories)
            {
                try
                {
                    interactions.AddRange(factory.GetInteractions(this).ToArray());
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"Interaction factory {factory} threw an exception when interacting with {Object}.");
                    RogueFramework.LogError(e.ToString());
                }
            }
            // all of the interactions are added to the list, initialize them
            Array.ForEach(interactions.ToArray(), i =>
            {
                try
                {
                    i.Model = this;
                    if (!i.SetupButton()) interactions.Remove(i);
                }
                catch (Exception e)
                {
                    RogueFramework.LogError(e, "SetupButton", interactions[0], Object);
                    interactions.Remove(i);
                }
            });
			// cancelling each other out
            foreach (Func<Interaction, bool> predicate in preventPredicates)
            {
                try
                {
                    interactions.RemoveAll(predicate.Invoke);
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"Prevention predicate {predicate} threw an exception.");
                    RogueFramework.LogError(e.ToString());
                }
            }

            // if there are no buttons at all, or if one of the buttons aborted the entire interaction
            if (interactions.Count is 0 || shouldStopInteracting)
            {
                CancelCallback?.Invoke(); // custom cancel callback
                // Object.StopInteraction(); // called implicitly?
                return;
            }

            // if there's only one button and it can be pressed implicitly
            if (interactions.Count is 1 && interactions[0].ImplicitAction)
            {
                try { interactions[0].OnPressedImplicitly(); }
                catch (Exception e) { RogueFramework.LogError(e, "OnPressedImplicitly", interactions[0], Object); }
                CancelCallback?.Invoke(); // custom cancel callback
                Object.StopInteraction(); // stop interaction
                return;
            }

			// add buttons to be displayed
            foreach (Interaction interaction in interactions)
            {
                Object.buttons.Add(interaction.ButtonName);
                Object.buttonPrices.Add(interaction.ButtonPrice ?? 0);
                Object.buttonsExtra.Add(interaction.ButtonExtra ?? string.Empty);
            }

            // trigger OnOpen, because the menu with the buttons will show up
            interactions.ForEach(i =>
            {
                try { i.OnOpen(); }
                catch (Exception e) { RogueFramework.LogError(e, "OnOpen", i, Object); }
            });

        }
        public void OnPressedButton(string buttonName)
        {
            // this will act as a replacement for the PlayfieldObject.PressedButton(...) method
            if (buttonName == "Done")
            {
                StopInteractionInternal(); // cancel interaction and invoke OnClose
                return;
            }
            Interaction interaction = interactions.Find(i => i.ButtonName == buttonName);
            if (interaction is null)
            {
                RogueFramework.LogError($"An interaction '{buttonName}' on {Object} could not be found.");
                return;
            }
            shouldStopInteracting = false;
            CancelCallback = null;

            try { interaction.OnPressed(); }
            catch (Exception e) { RogueFramework.LogError(e, "OnPressed", interaction, Object); }

            if (shouldStopInteracting) StopInteractionInternal(); // cancel interaction and invoke OnClose

            // TODO: otherwise, re-render the menu

        }

        private void StopInteractionInternal()
        {
            interactions.ForEach(i =>
            {
                try { i.OnClose(); }
                catch (Exception e) { RogueFramework.LogError(e, "OnClose", i, Object); }
            });
            Object.StopInteraction();
        }

    }
    public abstract class Interaction
    {
        public InteractionModel Model { get; internal set; }
        public PlayfieldObject Object => Model.Object;
        public Agent Agent => Model.Agent;
        public InteractionHelper Helper => Model.Helper;

        public abstract void OnPressed();
        public virtual void OnPressedImplicitly() => OnPressed();

        public string ButtonName { get; set; }
        public string ButtonText { get; set; }
        public int? ButtonPrice { get; set; }
        public string ButtonExtra { get; set; }

        public virtual bool ImplicitAction => false;

        protected bool SetButton(string buttonName)
            => SetButton(buttonName, null, null, null);
        protected bool SetButton(string buttonName, string buttonText)
            => SetButton(buttonName, buttonText, null, null);
        protected bool SetButton(string buttonName, string buttonText, string buttonExtra)
            => SetButton(buttonName, buttonText, null, buttonExtra);
        protected bool SetButton(string buttonName, string buttonText, int? buttonPrice, string buttonExtra)
        {
            ButtonName = buttonName;
            ButtonText = buttonText;
            ButtonPrice = buttonPrice;
            ButtonExtra = buttonExtra;
            return true;
        }

        public abstract bool SetupButton();

        public void StopInteraction() => Model.shouldStopInteracting = true;
        public void StopInteraction(Action callback)
        {
            Model.shouldStopInteracting = true;
            Model.CancelCallback = callback;
        }

        public virtual void OnOpen() { }    // TODO: not implemented yet, see WorldSpaceGUI.ShowObjectButtons(...)
        public virtual void WhileOpen() { } // TODO: not implemented yet
        public virtual void OnClose() { }   // TODO: not implemented yet, see WorldSpaceGUI.HideObjectButtons()

        public void CancelButton(string buttonName) => Model.preventPredicates.Add(i => i.ButtonName == buttonName);
        public void CancelButtons(Func<Interaction, bool> predicate) => Model.preventPredicates.Add(predicate);

    }
    public interface IInteractionFactory
    {
        IEnumerable<Interaction> GetInteractions(InteractionModel model);
    }
    public abstract class CustomInteraction : Interaction
    {
        public abstract bool MatchObject(PlayfieldObject obj);
    }
    public abstract class CustomInteraction<T> : CustomInteraction where T : PlayfieldObject
    {
        public new T Object => (T)Model.Object;
        public sealed override bool MatchObject(PlayfieldObject obj) => obj is T tObj && MatchObject(tObj);
        public abstract bool MatchObject(T obj);
    }
    public abstract class VanillaInteraction : Interaction
    {
        public bool CancelSelf(Action callback)
        {
            Model.interactions.Remove(this);
            Model.CancelCallback = callback;
            return false;
        }
    }
    public abstract class VanillaInteraction<T> : VanillaInteraction where T : PlayfieldObject
    {
        public new T Object => (T)Model.Object;
    }
    public class VanillaInteractionFactory : IInteractionFactory
    {
        private readonly List<Func<VanillaInteraction>> interactions = new List<Func<VanillaInteraction>>();
        public VanillaInteractionFactory With<T>() where T : VanillaInteraction, new()
        {
            interactions.Add(() => new T());
            return this;
        }

        public IEnumerable<Interaction> GetInteractions(InteractionModel model)
            => interactions.Select(i => i());
    }
}
