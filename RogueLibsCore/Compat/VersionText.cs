using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a version text displayed in the bottom-left corner of the screen. Does not necessarily display a version.</para>
    /// </summary>
    [Obsolete("VersionText was removed in RogueLibs v4.0.0.")]
    public class VersionText
    {
        /// <summary>
        ///   <para>Gets the version text's unique identifier.</para>
        /// </summary>
        public string Id { get; }
        /// <summary>
        ///   <para>Gets or sets the text displayed by the version text.</para>
        /// </summary>
        public string Text { get; set; }

        internal VersionText(string id, string? text)
        {
            Id = id;
            Text = text ?? string.Empty;
        }
    }
}
