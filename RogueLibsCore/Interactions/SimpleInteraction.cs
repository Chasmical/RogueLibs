using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an interaction created using a <see cref="SimpleInteractionProvider"/>.</para>
    /// </summary>
    public sealed class SimpleInteraction : CustomInteraction
    {
        /// <summary>
        ///   <para>Initializes an instance of the <see cref="SimpleInteraction"/> with the specified parameters.</para>
        /// </summary>
        /// <param name="name">The name of the interaction's button.</param>
        /// <param name="price">The price of the interaction's button.</param>
        /// <param name="extra">The extra information on the interaction's button.</param>
        /// <param name="implicitAction">Determines whether the interaction's button's action is implicit.</param>
        /// <param name="action">The action that gets called when the interaction's button is pressed.</param>
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
        /// <inheritdoc/>
        public override bool ImplicitAction { get; }

        private readonly Action<InteractionModel> _action;

        /// <inheritdoc/>
        public override bool MatchObject(InteractionModel model) => true;
        /// <inheritdoc/>
        public override bool SetupButton() => SetButton(_name, _price, _extra);
        /// <inheritdoc/>
        public override void OnPressed() => _action(Model);

    }
    /// <summary>
    ///   <para>Represents an interaction created using a <see cref="SimpleInteractionProvider{T}"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of the object that the interaction is for.</typeparam>
    public sealed class SimpleInteraction<T> : CustomInteraction<T> where T : PlayfieldObject
    {
        /// <summary>
        ///   <para>Initializes an instance of the <see cref="SimpleInteraction"/> with the specified parameters.</para>
        /// </summary>
        /// <param name="name">The name of the interaction's button.</param>
        /// <param name="price">The price of the interaction's button.</param>
        /// <param name="extra">The extra information on the interaction's button.</param>
        /// <param name="implicitAction">Determines whether the interaction's button's action is implicit.</param>
        /// <param name="action">The action that gets called when the interaction's button is pressed.</param>
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
        /// <inheritdoc/>
        public override bool ImplicitAction { get; }
        private readonly Action<InteractionModel<T>> _action;

        /// <inheritdoc/>
        public override bool SetupButton() => SetButton(_name, _price, _extra);
        /// <inheritdoc/>
        public override void OnPressed() => _action(Model);

    }
}
