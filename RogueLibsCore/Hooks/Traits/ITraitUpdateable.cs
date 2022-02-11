namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Indicates that a custom trait has an update coroutine.</para>
    /// </summary>
    public interface ITraitUpdateable
    {
        /// <summary>
        ///   <para>The method that is called as a part of the trait's update coroutine.</para>
        /// </summary>
        /// <param name="e">The custom trait's update data.</param>
        void OnUpdated(TraitUpdatedArgs e);
    }
}
