using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an index of languages' numeric versions.</para>
    /// </summary>
    public sealed class LanguageVersions : IXmlSerializable
    {
        internal LanguageVersions() { }
        private Dictionary<string, int>? entries;
        /// <summary>
        ///   <para>Gets a read-only dictionary of language ids to their versions.</para>
        /// </summary>
        public Dictionary<string, int> Entries => entries ??= new Dictionary<string, int>();

        /// <inheritdoc/>
        public void WriteXml(XmlWriter xml)
        {
            if (entries is not null)
                foreach (KeyValuePair<string, int> entry in entries)
                {
                    xml.WriteStartElement("Language");
                    xml.WriteAttributeString("Id", entry.Key);
                    xml.WriteAttributeString("Version", entry.Value.ToString());
                    xml.WriteEndAttribute();
                }
        }
        /// <inheritdoc/>
        public void ReadXml(XmlReader xml)
        {
            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            entries = new Dictionary<string, int>();
            if (nonEmpty)
            {
                xml.MoveToContent();
                while (xml.NodeType != XmlNodeType.EndElement)
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        string id = xml.GetAttribute("Id")!;
                        string versionAttr = xml.GetAttribute("Version")!;
                        entries.Add(id, int.Parse(versionAttr));
                    }
                    xml.Skip();
                    xml.MoveToContent();
                }
                xml.ReadEndElement();
            }

        }
        System.Xml.Schema.XmlSchema? IXmlSerializable.GetSchema() => null;
    }
}
