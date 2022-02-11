using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RogueLibsCore
{
    public abstract class Interaction
    {
        public InteractionModel Model { get; internal set; } = null!; // initialized immediately in InteractionModel
        public PlayfieldObject Object => Model.Object;
        public Agent Agent => Model.Agent;
        public InteractionHelper Helper => Model.Helper;

        public virtual bool ImplicitAction => false;

        public string? ButtonName { get; private set; }
        public int? ButtonPrice { get; private set; }
        public string? ButtonExtra { get; private set; }

        protected bool SetButton(string buttonName)
            => SetButton(buttonName, null, null);
        protected bool SetButton(string buttonName, string? buttonExtra)
            => SetButton(buttonName, null, buttonExtra);
        protected bool SetButton(string buttonName, int? buttonPrice)
            => SetButton(buttonName, buttonPrice, null);
        protected bool SetButton(string buttonName, int? buttonPrice, string? buttonExtra)
        {
            ButtonName = buttonName;
            ButtonPrice = buttonPrice;
            ButtonExtra = buttonExtra;
            return true;
        }

        protected void StopInteraction() => Model.StopInteraction();
        protected bool SetCallback(Action callback)
        {
            Model.CancelCallback ??= callback;
            return false;
        }

        public abstract bool SetupButton();
        public abstract void OnPressed();
        public virtual void OnPressedImplicitly() => OnPressed();

        public virtual void OnOpen() { }    // TODO
        public virtual void WhileOpen() { } // TODO
        public virtual void OnClose() { }   // TODO

        public virtual void OnMouseEnter() { } // TODO
        public virtual void OnMouseOver() { }  // TODO
        public virtual void OnMouseExit() { }  // TODO

    }
    public abstract class CustomInteraction : Interaction
    {
        public abstract bool MatchObject(InteractionModel model);
    }
    public abstract class CustomInteraction<T> : CustomInteraction where T : PlayfieldObject
    {
        public new InteractionModel<T> Model => (InteractionModel<T>)base.Model;
        public new T Object => Model.Object;

        public sealed override bool MatchObject(InteractionModel model)
            => model is InteractionModel<T> tModel && MatchObject(tModel);
        // ReSharper disable once UnusedParameter.Global
        public virtual bool MatchObject(InteractionModel<T> _) => true;

    }
    public sealed class SimpleInteraction : CustomInteraction
    {
        public SimpleInteraction(string name, int? price, string? extra, bool implicitAction, Action<InteractionModel> action)
        {
            _name = name;
            _price = price;
            _extra = extra;
            ImplicitAction = implicitAction;
            _action = action;
        }

        private readonly string _name;
        private readonly int? _price;
        private readonly string? _extra;
        public override bool ImplicitAction { get; }
        private readonly Action<InteractionModel> _action;

        public override bool MatchObject(InteractionModel model) => true;
        public override bool SetupButton() => SetButton(_name, _price, _extra);
        public override void OnPressed() => _action(Model);

    }
    public sealed class SimpleInteraction<T> : CustomInteraction<T> where T : PlayfieldObject
    {
        public SimpleInteraction(string name, int? price, string? extra, bool implicitAction, Action<InteractionModel<T>> action)
        {
            _name = name;
            _price = price;
            _extra = extra;
            ImplicitAction = implicitAction;
            _action = action;
        }

        private readonly string _name;
        private readonly int? _price;
        private readonly string? _extra;
        public override bool ImplicitAction { get; }
        private readonly Action<InteractionModel<T>> _action;

        public override bool SetupButton() => SetButton(_name, _price, _extra);
        public override void OnPressed() => _action(Model);

    }
    public interface IInteractionProvider
    {
        IEnumerable<Interaction> GetInteractions(InteractionModel model);
    }
    public class SimpleInteractionProvider : IInteractionProvider
    {
        public SimpleInteractionProvider(Action<SimpleInteractionProvider> handler) => _handler = handler;

        private readonly Action<SimpleInteractionProvider> _handler;
        private readonly List<Interaction> interactions = new List<Interaction>();

        private void EnsureModel()
        {
            if (_model is null) throw new InvalidOperationException(
                "SimpleInteractionProvider<T> instance must only be accessed in the handler delegate."
                + " In button callbacks use the passed parameter to access associated properties.");
        }

        public SimpleInteraction AddButton(string buttonName, Action<InteractionModel> action)
            => AddButton(buttonName, null, null, action);
        public SimpleInteraction AddButton(string buttonName, string? buttonExtra, Action<InteractionModel> action)
            => AddButton(buttonName, null, buttonExtra, action);
        public SimpleInteraction AddButton(string buttonName, int? buttonPrice, Action<InteractionModel> action)
            => AddButton(buttonName, buttonPrice, null, action);
        public SimpleInteraction AddButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel> action)
        {
            EnsureModel();
            SimpleInteraction interaction = new SimpleInteraction(buttonName, buttonPrice, buttonExtra, false, action);
            interactions.Add(interaction);
            return interaction;
        }

        public SimpleInteraction AddImplicitButton(string buttonName, Action<InteractionModel> action)
            => AddImplicitButton(buttonName, null, null, action);
        public SimpleInteraction AddImplicitButton(string buttonName, string? buttonExtra, Action<InteractionModel> action)
            => AddImplicitButton(buttonName, null, buttonExtra, action);
        public SimpleInteraction AddImplicitButton(string buttonName, int? buttonPrice, Action<InteractionModel> action)
            => AddImplicitButton(buttonName, buttonPrice, null, action);
        public SimpleInteraction AddImplicitButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel> action)
        {
            EnsureModel();
            SimpleInteraction interaction = new SimpleInteraction(buttonName, buttonPrice, buttonExtra, true, action);
            interactions.Add(interaction);
            return interaction;
        }

        public Action SetStopCallback(Action<InteractionModel> stopCallback)
        {
            EnsureModel();
            InteractionModel model = Model;
            void Callback() => stopCallback(model);
            model.CancelCallback ??= Callback;
            return Callback;
        }

        private InteractionModel? _model;
        public InteractionModel Model
        {
            get
            {
                EnsureModel();
                return _model!;
            }
        }
        public PlayfieldObject Object => Model.Object;
        public Agent Agent => Model.Agent;
        public InteractionHelper Helper => Model.Helper;
        // ReSharper disable once InconsistentNaming
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "That's how it's called in the original code")]
        public GameController gc => GameController.gameController;

        IEnumerable<Interaction> IInteractionProvider.GetInteractions(InteractionModel model)
        {
            interactions.Clear();
            try
            {
                _model = model;
                _handler(this);
            }
            catch (Exception e)
            {
                RogueFramework.LogError($"SimpleInteractionProvider's handler on {Object} threw an exception.");
                RogueFramework.LogError(e.ToString());
            }
            finally
            {
                _model = null;
            }
            return interactions;
        }

    }
    public class SimpleInteractionProvider<T> : IInteractionProvider where T : PlayfieldObject
    {
        public SimpleInteractionProvider(Action<SimpleInteractionProvider<T>> handler) => _handler = handler;

        private readonly Action<SimpleInteractionProvider<T>> _handler;
        private readonly List<Interaction> interactions = new List<Interaction>();

        private void EnsureModel()
        {
            if (_model is null) throw new InvalidOperationException(
                "SimpleInteractionProvider<T> instance must only be accessed in the handler delegate."
                + " In button callbacks use the passed parameter to access associated properties.");
        }

        public SimpleInteraction<T> AddButton(string buttonName, Action<InteractionModel<T>> action)
            => AddButton(buttonName, null, null, action);
        public SimpleInteraction<T> AddButton(string buttonName, string? buttonExtra, Action<InteractionModel<T>> action)
            => AddButton(buttonName, null, buttonExtra, action);
        public SimpleInteraction<T> AddButton(string buttonName, int? buttonPrice, Action<InteractionModel<T>> action)
            => AddButton(buttonName, buttonPrice, null, action);
        public SimpleInteraction<T> AddButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel<T>> action)
        {
            EnsureModel();
            SimpleInteraction<T> interaction = new SimpleInteraction<T>(buttonName, buttonPrice, buttonExtra, false, action);
            interactions.Add(interaction);
            return interaction;
        }

        public SimpleInteraction<T> AddImplicitButton(string buttonName, Action<InteractionModel<T>> action)
            => AddImplicitButton(buttonName, null, null, action);
        public SimpleInteraction<T> AddImplicitButton(string buttonName, string? buttonExtra, Action<InteractionModel<T>> action)
            => AddImplicitButton(buttonName, null, buttonExtra, action);
        public SimpleInteraction<T> AddImplicitButton(string buttonName, int? buttonPrice, Action<InteractionModel<T>> action)
            => AddImplicitButton(buttonName, buttonPrice, null, action);
        public SimpleInteraction<T> AddImplicitButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel<T>> action)
        {
            EnsureModel();
            SimpleInteraction<T> interaction = new SimpleInteraction<T>(buttonName, buttonPrice, buttonExtra, true, action);
            interactions.Add(interaction);
            return interaction;
        }

        public Action SetStopCallback(Action<InteractionModel<T>> stopCallback)
        {
            EnsureModel();
            InteractionModel<T> model = Model;
            void Callback() => stopCallback(model);
            model.CancelCallback ??= Callback;
            return Callback;
        }

        private InteractionModel<T>? _model;
        public InteractionModel<T> Model
        {
            get
            {
                EnsureModel();
                return _model!;
            }
        }
        public T Object => Model.Object;
        public Agent Agent => Model.Agent;
        public InteractionHelper Helper => Model.Helper;
        // ReSharper disable once InconsistentNaming
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "That's how it's called in the original code")]
        public GameController gc => GameController.gameController;

        IEnumerable<Interaction> IInteractionProvider.GetInteractions(InteractionModel model)
        {
            if (model is InteractionModel<T> tModel)
            {
                interactions.Clear();
                try
                {
                    _model = tModel;
                    _handler(this);
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"SimpleInteractionProvider's handler on {Object} threw an exception.");
                    RogueFramework.LogError(e.ToString());
                }
                finally
                {
                    _model = null;
                }
                return interactions;
            }
            return Enumerable.Empty<Interaction>();
        }

    }
}
