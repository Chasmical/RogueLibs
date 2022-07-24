using UnityEngine.UI;

namespace RogueLibsCore
{
    public class VersionText
    {
        internal VersionText(string id) => Id = id;
        internal VersionText(string id, string? text) : this(id) => preparedText = text;
        public string Id { get; }
        private Text? textComponent;
        private string? preparedText;
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
