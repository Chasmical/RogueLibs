using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a localizable string.</para>
    /// </summary>
    public interface IName : IEnumerable<KeyValuePair<LanguageCode, string>>
    {
        /// <summary>
        ///   <para>Gets or sets the specified <paramref name="language"/>'s localization text.</para>
        /// </summary>
        /// <param name="language">The language to get or set the localization text for.</param>
        /// <returns>The specified <paramref name="language"/>'s localization text, if found; otherwise, <see langword="null"/>.</returns>
        string? this[LanguageCode language] { get; set; }
    }
}
