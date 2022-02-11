namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a localization text provider.</para>
    /// </summary>
    public interface INameProvider
    {
        /// <summary>
        ///   <para>Tries to get the localization text for the specified <paramref name="name"/> and <paramref name="type"/>.</para>
        /// </summary>
        /// <param name="name">The name of the entry.</param>
        /// <param name="type">The type of the entry.</param>
        /// <param name="result">The localization text, or <see langword="null"/>, if a valid localization text could not be found.</param>
        void GetName(string? name, string? type, ref string? result);
    }
}
