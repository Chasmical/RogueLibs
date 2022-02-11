using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    [XmlRoot("Category")]
    public sealed class LocaleCategory : IXmlSerializable
    {
        internal LocaleCategory() { }
        public string Id { get; private set; }
        private Dictionary<string, string> entries;
        public ReadOnlyDictionary<string, string> Entries { get; private set; }

        public void WriteXml(XmlWriter xml)
        {
            xml.WriteAttributeString("Id", Id);
            foreach (KeyValuePair<string, string> entry in entries)
            {
                xml.WriteStartElement("Entry");
                xml.WriteAttributeString("Id", entry.Key);
                xml.WriteString(entry.Value);
                xml.WriteEndElement();
            }
        }
        public void ReadXml(XmlReader xml)
        {
            Id = xml.GetAttribute("Id");
            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            entries = new Dictionary<string, string>();
            Entries = new ReadOnlyDictionary<string, string>(entries);
            if (nonEmpty)
            {
                xml.MoveToContent();
                while (xml.NodeType != XmlNodeType.EndElement)
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        string id = xml.GetAttribute("Id");
                        string content = xml.ReadElementContentAsString();
                        entries.Add(id, content);
                    }
                    else xml.Skip();
                    xml.MoveToContent();
                }
                xml.ReadEndElement();
            }
        }
        public System.Xml.Schema.XmlSchema GetSchema() => null;

        public string this[string name] => name != null && entries.TryGetValue(name, out string text) ? text : null;
    }
}
