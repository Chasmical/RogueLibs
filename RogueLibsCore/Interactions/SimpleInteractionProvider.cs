using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a simple interaction provider that uses a delegate to handle interactions.</para>
    /// </summary>
    public class SimpleInteractionProvider : IInteractionProvider
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="SimpleInteractionProvider"/> class with the specified <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="handler">A delegate that handles interactions using this interaction provider.</param>
        public SimpleInteractionProvider(Action<SimpleInteractionProvider> handler) => _handler = handler;

        private readonly Action<SimpleInteractionProvider> _handler;
        private readonly List<Interaction> interactions = new List<Interaction>();

        private void EnsureModel()
        {
            if (_model is null) throw new InvalidOperationException(
                "SimpleInteractionProvider<T> instance must only be accessed in the handler delegate."
                + " In button callbacks use the passed parameter to access associated properties.");
        }

        /// <inheritdoc cref="InteractionModel.RemoveInteraction(string)"/>
        public bool RemoveButton(string buttonName)
            => Model.RemoveInteraction(buttonName);
        /// <inheritdoc cref="InteractionModel.RemoveInteraction(Predicate{Interaction})"/>
        public bool RemoveButton(Predicate<Interaction> predicate)
            => Model.RemoveInteraction(predicate);

        /// <inheritdoc cref="InteractionModel.HasInteraction(string)"/>
        public bool HasButton(string buttonName)
            => Model.HasInteraction(buttonName);
        /// <inheritdoc cref="InteractionModel.HasInteraction(Predicate{Interaction})"/>
        public bool HasButton(Predicate<Interaction> predicate)
            => Model.HasInteraction(predicate);

        /// <summary>
        ///   <para>Adds an interaction with the specified <paramref name="buttonName"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddButton(string buttonName, Action<InteractionModel> action)
            => AddButton(buttonName, null, null, action);
        /// <summary>
        ///   <para>Adds an interaction with the specified <paramref name="buttonName"/>, <paramref name="buttonExtra"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="buttonExtra">The extra information on the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddButton(string buttonName, string? buttonExtra, Action<InteractionModel> action)
            => AddButton(buttonName, null, buttonExtra, action);
        /// <summary>
        ///   <para>Adds an interaction with the specified <paramref name="buttonName"/>, <paramref name="buttonPrice"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="buttonPrice">The price of the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddButton(string buttonName, int? buttonPrice, Action<InteractionModel> action)
            => AddButton(buttonName, buttonPrice, null, action);
        /// <summary>
        ///   <para>Adds an interaction with the specified <paramref name="buttonName"/>, <paramref name="buttonPrice"/>, <paramref name="buttonExtra"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="buttonPrice">The price of the interaction's button.</param>
        /// <param name="buttonExtra">The extra information on the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel> action)
        {
            EnsureModel();
            SimpleInteraction interaction = new SimpleInteraction(buttonName, buttonPrice, buttonExtra, false, action);
            interactions.Add(interaction);
            return interaction;
        }

        /// <summary>
        ///   <para>Adds an implicit interaction with the specified <paramref name="buttonName"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddImplicitButton(string buttonName, Action<InteractionModel> action)
            => AddImplicitButton(buttonName, null, null, action);
        /// <summary>
        ///   <para>Adds an implicit interaction with the specified <paramref name="buttonName"/>, <paramref name="buttonExtra"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="buttonExtra">The extra information on the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddImplicitButton(string buttonName, string? buttonExtra, Action<InteractionModel> action)
            => AddImplicitButton(buttonName, null, buttonExtra, action);
        /// <summary>
        ///   <para>Adds an implicit interaction with the specified <paramref name="buttonName"/>, <paramref name="buttonPrice"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="buttonPrice">The price of the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddImplicitButton(string buttonName, int? buttonPrice, Action<InteractionModel> action)
            => AddImplicitButton(buttonName, buttonPrice, null, action);
        /// <summary>
        ///   <para>Adds an implicit interaction with the specified <paramref name="buttonName"/>, <paramref name="buttonPrice"/>, <paramref name="buttonExtra"/> and <paramref name="action"/> to the model.</para>
        /// </summary>
        /// <param name="buttonName">The name of the interaction's button.</param>
        /// <param name="buttonPrice">The price of the interaction's button.</param>
        /// <param name="buttonExtra">The extra information on the interaction's button.</param>
        /// <param name="action">The interaction's action.</param>
        /// <returns>The created <see cref="SimpleInteraction"/> instance.</returns>
        public SimpleInteraction AddImplicitButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel> action)
        {
            EnsureModel();
            SimpleInteraction interaction = new SimpleInteraction(buttonName, buttonPrice, buttonExtra, true, action);
            interactions.Add(interaction);
            return interaction;
        }

        /// <summary>
        ///   <para>Sets the specified stop <paramref name="callback"/> that gets called if the interaction fails, is stopped or is interrupted.</para>
        /// </summary>
        /// <param name="callback">The stop callback to set.</param>
        public void SetStopCallback(Action<InteractionModel> callback)
        {
            EnsureModel();
            InteractionModel model = _model!;
            void Callback() => callback(model);
            _model!.StopCallback = Callback;
        }
        /// <summary>
        ///   <para>Combines the specified stop <paramref name="callback"/> with any previously defined ones.</para>
        /// </summary>
        /// <param name="callback">The stop callback to combine with any previously defined ones.</param>
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
        /// <summary>
        ///   <para>Sets the specified <paramref name="sideEffect"/> that gets called after the interactions are set up, regardless of whether it was successful.</para>
        /// </summary>
        /// <param name="sideEffect">The side effect to set.</param>
        public void SetSideEffect(Action<InteractionModel> sideEffect)
        {
            EnsureModel();
            InteractionModel model = _model!;
            void SideEffect() => sideEffect(model);
            _model!.SideEffect = SideEffect;
        }
        /// <summary>
        ///   <para>Combines the specified <paramref name="sideEffect"/> with any previously defined ones.</para>
        /// </summary>
        /// <param name="sideEffect">The side effect to combine with any previously defined ones.</param>
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

        public void RemoveDoneButton() => Model.AddDoneButton = false;

        private InteractionModel? _model;
        /// <summary>
        ///   <para>Gets the interaction model that the provider provides interactions for.</para>
        /// </summary>
        public InteractionModel Model
        {
            get
            {
                EnsureModel();
                return _model!;
            }
        }
        /// <summary>
        ///   <para>Gets the object that is being interacted with.</para>
        /// </summary>
        public PlayfieldObject Object => Model.Object;
        /// <summary>
        ///   <para>Gets the agent that is interacting with an object.</para>
        /// </summary>
        public Agent Agent => Model.Agent;
        /// <summary>
        ///   <para>Gets the <see cref="InteractionHelper"/> of the current interaction.</para>
        /// </summary>
        public InteractionHelper Helper => Model.Helper;

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
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
    /// <summary>
    ///   <para>Represents a simple interaction provider that uses a delegate to handle interactions.</para>
    /// </summary>
    /// <typeparam name="T">The type of the object that the interactions are for.</typeparam>
    public class SimpleInteractionProvider<T> : IInteractionProvider where T : PlayfieldObject
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="SimpleInteractionProvider{T}"/> class with the specified <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="handler">A delegate that handles interactions using this interaction provider.</param>
        public SimpleInteractionProvider(Action<SimpleInteractionProvider<T>> handler) => _handler = handler;

        private readonly Action<SimpleInteractionProvider<T>> _handler;
        private readonly List<Interaction> interactions = new List<Interaction>();

        private void EnsureModel()
        {
            if (_model is null) throw new InvalidOperationException(
                "SimpleInteractionProvider<T> instance must only be accessed in the handler delegate."
                + " In button callbacks use the passed parameter to access associated properties.");
        }

        /// <inheritdoc cref="InteractionModel.RemoveInteraction(string)"/>
        public bool RemoveButton(string buttonName)
            => Model.RemoveInteraction(buttonName);
        /// <inheritdoc cref="InteractionModel.RemoveInteraction(Predicate{Interaction})"/>
        public bool RemoveButton(Predicate<Interaction> predicate)
            => Model.RemoveInteraction(predicate);

        /// <inheritdoc cref="InteractionModel.HasInteraction(string)"/>
        public bool HasButton(string buttonName)
            => Model.HasInteraction(buttonName);
        /// <inheritdoc cref="InteractionModel.HasInteraction(Predicate{Interaction})"/>
        public bool HasButton(Predicate<Interaction> predicate)
            => Model.HasInteraction(predicate);

        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddButton(string, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddButton(string buttonName, Action<InteractionModel<T>> action)
            => AddButton(buttonName, null, null, action);
        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddButton(string, string?, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddButton(string buttonName, string? buttonExtra, Action<InteractionModel<T>> action)
            => AddButton(buttonName, null, buttonExtra, action);
        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddButton(string, int?, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddButton(string buttonName, int? buttonPrice, Action<InteractionModel<T>> action)
            => AddButton(buttonName, buttonPrice, null, action);
        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddButton(string, int?, string?, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel<T>> action)
        {
            EnsureModel();
            SimpleInteraction<T> interaction = new SimpleInteraction<T>(buttonName, buttonPrice, buttonExtra, false, action);
            interactions.Add(interaction);
            return interaction;
        }

        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddImplicitButton(string, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddImplicitButton(string buttonName, Action<InteractionModel<T>> action)
            => AddImplicitButton(buttonName, null, null, action);
        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddImplicitButton(string, string?, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddImplicitButton(string buttonName, string? buttonExtra, Action<InteractionModel<T>> action)
            => AddImplicitButton(buttonName, null, buttonExtra, action);
        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddImplicitButton(string, int?, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddImplicitButton(string buttonName, int? buttonPrice, Action<InteractionModel<T>> action)
            => AddImplicitButton(buttonName, buttonPrice, null, action);
        /// <returns>The created <see cref="SimpleInteraction{T}"/> instance.</returns>
        /// <inheritdoc cref="SimpleInteractionProvider.AddImplicitButton(string, int?, string?, Action{InteractionModel})"/>
        public SimpleInteraction<T> AddImplicitButton(string buttonName, int? buttonPrice, string? buttonExtra, Action<InteractionModel<T>> action)
        {
            EnsureModel();
            SimpleInteraction<T> interaction = new SimpleInteraction<T>(buttonName, buttonPrice, buttonExtra, true, action);
            interactions.Add(interaction);
            return interaction;
        }

        /// <inheritdoc cref="SimpleInteractionProvider.SetStopCallback(Action{InteractionModel})"/>
        public void SetStopCallback(Action<InteractionModel<T>> callback)
        {
            EnsureModel();
            InteractionModel<T> model = _model!;
            void Callback() => callback(model);
            _model!.StopCallback = Callback;
        }
        /// <inheritdoc cref="SimpleInteractionProvider.CombineStopCallback(Action{InteractionModel})"/>
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
        /// <inheritdoc cref="SimpleInteractionProvider.SetSideEffect(Action{InteractionModel})"/>
        public void SetSideEffect(Action<InteractionModel<T>> sideEffect)
        {
            EnsureModel();
            InteractionModel<T> model = _model!;
            void SideEffect() => sideEffect(model);
            _model!.SideEffect = SideEffect;
        }
        /// <inheritdoc cref="SimpleInteractionProvider.CombineSideEffect(Action{InteractionModel})"/>
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

        private InteractionModel<T>? _model;
        /// <inheritdoc cref="SimpleInteractionProvider.Model"/>
        public InteractionModel<T> Model
        {
            get
            {
                EnsureModel();
                return _model!;
            }
        }
        /// <inheritdoc cref="SimpleInteractionProvider.Object"/>
        public T Object => Model.Object;
        /// <inheritdoc cref="SimpleInteractionProvider.Agent"/>
        public Agent Agent => Model.Agent;
        /// <inheritdoc cref="SimpleInteractionProvider.Helper"/>
        public InteractionHelper Helper => Model.Helper;

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
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
