using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    [XmlRoot("Language")]
    public sealed class LocaleLanguage : IXmlSerializable
    {
        private LocaleLanguage() { }
        public string Id { get; private set; } = null!; // initialized on deserialization
        public int Version { get; private set; }
        public LanguageCode Code { get; internal set; }
        private Dictionary<string, LocaleCategory>? categories;
        public ReadOnlyDictionary<string, LocaleCategory> Categories { get; private set; } = null!; // initialized on deserialization

        public void WriteXml(XmlWriter xml)
        {
            xml.WriteAttributeString("Id", Id);
            if (Version != 0) xml.WriteAttributeString("Version", Version.ToString());
			if (categories is not null)
                foreach (LocaleCategory category in categories.Values)
                {
                    xml.WriteStartElement("Category");
                    category.WriteXml(xml);
                    xml.WriteEndElement();
                }
        }
        public void ReadXml(XmlReader xml)
        {
            Id = xml.GetAttribute("Id")!;
            string versionAttr = xml.GetAttribute("Version")!;
            if (!string.IsNullOrEmpty(versionAttr)) Version = int.Parse(versionAttr);
            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            categories = new Dictionary<string, LocaleCategory>();
            Categories = new ReadOnlyDictionary<string, LocaleCategory>(categories);
            if (nonEmpty)
            {
                xml.MoveToContent();
                while (xml.NodeType != XmlNodeType.EndElement)
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        LocaleCategory category = new LocaleCategory();
                        category.ReadXml(xml);
                        categories.Add(category.Id, category);
                    }
                    else xml.Skip();
                    xml.MoveToContent();
                }
                xml.ReadEndElement();
            }
        }
        public System.Xml.Schema.XmlSchema? GetSchema() => null;

        public string? this[string category, string name]
            => categories is not null && categories.TryGetValue(category, out LocaleCategory? cat) ? cat[name] : null;
    }
}
