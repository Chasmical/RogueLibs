using UnityEngine.UI;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a version text displayed in the bottom-left corner of the screen. Does not necessarily display a version.</para>
    /// </summary>
    public class VersionText
    {
        internal VersionText(string id) => Id = id;
        internal VersionText(string id, string? text) : this(id) => preparedText = text;
        /// <summary>
        ///   <para>Gets the version text's unique identifier.</para>
        /// </summary>
        public string Id { get; }

        private Text? textComponent;
        private string? preparedText;
        /// <summary>
        ///   <para>Gets or sets the text displayed by the version text.</para>
        /// </summary>
        public string Text
        {
            get => textComponent != null ? textComponent.text : preparedText ?? string.Empty;
            set
            {
                if (textComponent != null) textComponent.text = value;
                else preparedText = value;
            }
        }
        internal void AssignText(Text text)
        {
            textComponent = text;
            text.text = preparedText ?? string.Empty;
        }
    }
}
