namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Indicates that this hook class should be updated with Unity's LateUpdate method.</para>
    /// </summary>
    public interface IDoLateUpdate
    {
        /// <summary>
        ///   <para>The Unity's LateUpdate method, that is called once per frame after everything else, but before the render.</para>
        /// </summary>
        void LateUpdate();
    }
}
