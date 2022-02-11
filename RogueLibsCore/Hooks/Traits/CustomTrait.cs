namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom trait.</para>
    /// </summary>
    public abstract class CustomTrait : HookBase<Trait>
    {
        /// <summary>
        ///   <para>Gets the current <see cref="global::Trait"/> instance.</para>
        /// </summary>
        public Trait Trait => Instance;
        /// <summary>
        ///   <para>Gets the trait's <see cref="StatusEffects"/> instance.</para>
        /// </summary>
        public StatusEffects StatusEffects => Trait.GetStatusEffects();
        /// <summary>
        ///   <para>Gets the trait's owner.</para>
        /// </summary>
        public Agent Owner => Trait.GetStatusEffects().agent;

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        public static GameController gc => GameController.gameController;

        /// <summary>
        ///   <para>Gets the custom trait's metadata.</para>
        /// </summary>
        public TraitInfo TraitInfo { get; internal set; } = null!; // initialized immediately in CustomTraitFactory

        /// <inheritdoc/>
        protected sealed override void Initialize() => OnAdded();

        /// <summary>
        ///   <para>The method that is called when the trait is added.</para>
        /// </summary>
        public abstract void OnAdded();
        /// <summary>
        ///   <para>The method that is called when the trait is removed.</para>
        /// </summary>
        public abstract void OnRemoved();
    }
}
