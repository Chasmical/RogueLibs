using System;

namespace RogueLibsCore
{
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
}
