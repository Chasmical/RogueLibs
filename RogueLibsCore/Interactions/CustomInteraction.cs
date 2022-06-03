namespace RogueLibsCore
{
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
}
