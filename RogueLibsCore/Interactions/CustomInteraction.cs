namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an interaction. An unnecessary layer of abstraction, but it's kind of late to fix that now.</para>
    /// </summary>
    public abstract class CustomInteraction : Interaction
    {
        /// <summary>
        ///   <para>Matches the interaction models that the interaction is valid for.</para>
        /// </summary>
        /// <param name="model">The <see cref="InteractionModel"/> to match.</param>
        /// <returns><see langword="true"/>, if the interaction is valid for the specified <paramref name="model"/>; otherwise, <see langword="false"/>.</returns>
        public abstract bool MatchObject(InteractionModel model);
    }
    /// <summary>
    ///   <para>Represents an interaction. An unnecessary layer of abstraction, but it's kind of late to fix that now.</para>
    /// </summary>
    /// <typeparam name="T">The type of the object that the interaction is for.</typeparam>
    public abstract class CustomInteraction<T> : CustomInteraction where T : PlayfieldObject
    {
        /// <summary>
        ///   <para>Gets the <see cref="InteractionModel{T}"/> that the interaction was created for.</para>
        /// </summary>
        public new InteractionModel<T> Model => (InteractionModel<T>)base.Model;
        /// <summary>
        ///   <para>Gets the object that the interaction was created for.</para>
        /// </summary>
        public new T Object => Model.Object;

        /// <summary>
        ///   <para>Matches the interaction models that are instances of the <see cref="InteractionModel{T}"/> type.</para>
        /// </summary>
        /// <param name="model">The <see cref="InteractionModel"/> to match.</param>
        /// <returns><see langword="true"/>, if the <paramref name="model"/> is an instance of the <see cref="InteractionModel{T}"/> type; otherwise, <see langword="false"/>.</returns>
        public sealed override bool MatchObject(InteractionModel model)
            => model is InteractionModel<T> tModel && MatchObject(tModel);
        /// <summary>
        ///   <para>Matches the interaction models that the interaction is valid for.</para>
        /// </summary>
        /// <param name="model">The <see cref="InteractionModel{T}"/> to match.</param>
        /// <returns><see langword="true"/>, if the interaction is valid for the specified <paramref name="model"/>; otherwise, <see langword="false"/>.</returns>
        // ReSharper disable once UnusedParameter.Global
        public virtual bool MatchObject(InteractionModel<T> model) => true;

    }
}
