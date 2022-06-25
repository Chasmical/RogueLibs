using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RogueLibsCore
{
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

        public bool RemoveButton(string buttonName)
            => Model.RemoveInteraction(buttonName);
        public bool RemoveButton(Predicate<Interaction> predicate)
            => Model.RemoveInteraction(predicate);

        public bool HasButton(string buttonName)
            => Model.HasInteraction(buttonName);
        public bool HasButton(Predicate<Interaction> predicate)
            => Model.HasInteraction(predicate);

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

        public void SetStopCallback(Action<InteractionModel> callback)
        {
            EnsureModel();
            InteractionModel model = _model!;
            void Callback() => callback(model);
            _model!.StopCallback = Callback;
        }
        public void CombineStopCallback(Action<InteractionModel> callback)
        {
            EnsureModel();
            InteractionModel model = _model!;
            Action? previousCallback = model.StopCallback;
            void Callback()
            {
                callback(model);
                previousCallback?.Invoke();
            }
            model.StopCallback = Callback;
        }
        public void SetSideEffect(Action<InteractionModel> sideEffect)
        {
            EnsureModel();
            InteractionModel model = _model!;
            void SideEffect() => sideEffect(model);
            _model!.SideEffect = SideEffect;
        }
        public void CombineSideEffect(Action<InteractionModel> sideEffect)
        {
            EnsureModel();
            InteractionModel model = _model!;
            Action? previousCallback = model.StopCallback;
            void SideEffect()
            {
                sideEffect(model);
                previousCallback?.Invoke();
            }
            _model!.SideEffect = SideEffect;
        }
        public void StopInteraction() => Model.StopInteraction();

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

        Interaction[] IInteractionProvider.GetInteractions(InteractionModel model)
        {
            try
            {
                _model = model;
                _handler(this);
            }
            catch (Exception e)
            {
                RogueFramework.LogError($"SimpleInteractionProvider's handler on {Object} threw an exception.");
                RogueFramework.LogError(e.ToString());
                RogueFramework.LogError(_handler.Method);
            }
            finally
            {
                _model = null;
            }
            Interaction[] array = interactions.ToArray();
            interactions.Clear();
            return array;
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

        public bool RemoveButton(string buttonName)
            => Model.RemoveInteraction(buttonName);
        public bool RemoveButton(Predicate<Interaction> predicate)
            => Model.RemoveInteraction(predicate);

        public bool HasButton(string buttonName)
            => Model.HasInteraction(buttonName);
        public bool HasButton(Predicate<Interaction> predicate)
            => Model.HasInteraction(predicate);

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

        public void SetStopCallback(Action<InteractionModel<T>> callback)
        {
            EnsureModel();
            InteractionModel<T> model = _model!;
            void Callback() => callback(model);
            _model!.StopCallback = Callback;
        }
        public void CombineStopCallback(Action<InteractionModel<T>> callback)
        {
            EnsureModel();
            InteractionModel<T> model = _model!;
            Action? previousCallback = model.StopCallback;
            void Callback()
            {
                callback(model);
                previousCallback?.Invoke();
            }
            model.StopCallback = Callback;
        }
        public void SetSideEffect(Action<InteractionModel<T>> sideEffect)
        {
            EnsureModel();
            InteractionModel<T> model = _model!;
            void SideEffect() => sideEffect(model);
            _model!.SideEffect = SideEffect;
        }
        public void CombineSideEffect(Action<InteractionModel<T>> sideEffect)
        {
            EnsureModel();
            InteractionModel<T> model = _model!;
            Action? previousCallback = model.StopCallback;
            void SideEffect()
            {
                sideEffect(model);
                previousCallback?.Invoke();
            }
            _model!.SideEffect = SideEffect;
        }
        public void StopInteraction() => Model.StopInteraction();

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

        Interaction[] IInteractionProvider.GetInteractions(InteractionModel model)
        {
            if (model is InteractionModel<T> tModel)
            {
                try
                {
                    _model = tModel;
                    _handler(this);
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"SimpleInteractionProvider's handler on {Object} threw an exception.");
                    RogueFramework.LogError(e.ToString());
                    RogueFramework.LogError(_handler.Method);
                }
                finally
                {
                    _model = null;
                }
                Interaction[] array = interactions.ToArray();
                interactions.Clear();
                return array;
            }
            return Array.Empty<Interaction>();
        }

    }
}
