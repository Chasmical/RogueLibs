using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a localization category, containing localization entries.</para>
    /// </summary>
    [XmlRoot("Category")]
    public sealed class LocaleCategory : IXmlSerializable
    {
        internal LocaleCategory() { }
        /// <summary>
        ///   <para>Gets the category's identifier.</para>
        /// </summary>
        public string Id { get; private set; } = null!; // initialized on deserialization
        private Dictionary<string, string>? entries;
        /// <summary>
        ///   <para>Gets the category's underlying dictionary of entry ids to their values.</para>
        /// </summary>
        public Dictionary<string, string> Entries => entries ??= new Dictionary<string, string>();

        /// <inheritdoc/>
        public void WriteXml(XmlWriter xml)
        {
            xml.WriteAttributeString("Id", Id);
            if (entries is not null)
                foreach (KeyValuePair<string, string> entry in entries)
                {
                    xml.WriteStartElement("Entry");
                    xml.WriteAttributeString("Id", entry.Key);
                    xml.WriteString(entry.Value);
                    xml.WriteEndElement();
                }
        }
        /// <inheritdoc/>
        public void ReadXml(XmlReader xml)
        {
            Id = xml.GetAttribute("Id")!;
            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            entries = new Dictionary<string, string>();
            if (nonEmpty)
            {
                xml.MoveToContent();
                while (xml.NodeType != XmlNodeType.EndElement)
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        string id = xml.GetAttribute("Id")!;
                        string content = xml.ReadElementContentAsString();
                        entries.Add(id, content);
                    }
                    else xml.Skip();
                    xml.MoveToContent();
                }
                xml.ReadEndElement();
            }
        }
        System.Xml.Schema.XmlSchema? IXmlSerializable.GetSchema() => null;

        /// <summary>
        ///   <para>Returns the value of an entry with the specified <paramref name="name"/>, if found; otherwise, <see langword="null"/>.</para>
        /// </summary>
        /// <param name="name">The name of the entry to look for.</param>
        /// <returns>The value of an entry with the specified <paramref name="name"/>, if found; otherwise, <see langword="null"/>.</returns>
        public string? this[string name] => entries is not null && entries.TryGetValue(name, out string? text) ? text : null;
    }
}
