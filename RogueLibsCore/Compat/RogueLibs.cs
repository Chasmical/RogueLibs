using System;

namespace RogueLibsCore
{
    public static partial class RogueLibs
    {
        /// <summary>
        ///   <para>Creates a <see cref="VersionText"/>, that is displayed in the bottom-left corner, with the specified unique <paramref name="id"/> and initializes it with the specified <paramref name="text"/> value.</para>
        /// </summary>
        /// <param name="id">The unique identifier representing the <see cref="VersionText"/>.</param>
        /// <param name="text">The value to initialize the <see cref="VersionText"/> with.</param>
        /// <returns>The created <see cref="VersionText"/>.</returns>
        [Obsolete("VersionText was removed in RogueLibs v4.0.0.")]
        public static VersionText CreateVersionText(string id, string? text)
            => new VersionText(id, text);
    }
}
