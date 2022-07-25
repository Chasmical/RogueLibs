using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a localization language, containing localization categories.</para>
    /// </summary>
    [XmlRoot("Language")]
    public sealed class LocaleLanguage : IXmlSerializable
    {
        internal LocaleLanguage() { }
        /// <summary>
        ///   <para>Gets the language's identifier.</para>
        /// </summary>
        public string Id { get; private set; } = null!; // initialized on deserialization
        /// <summary>
        ///   <para>Gets the language's numeric version.</para>
        /// </summary>
        public int Version { get; private set; }
        private Dictionary<string, LocaleCategory>? categories;
        /// <summary>
        ///   <para>Gets the language's underlying dictionary of categories.</para>
        /// </summary>
        public Dictionary<string, LocaleCategory> Categories => categories ??= new Dictionary<string, LocaleCategory>();

        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public void ReadXml(XmlReader xml)
        {
            Id = xml.GetAttribute("Id")!;
            string versionAttr = xml.GetAttribute("Version")!;
            if (!string.IsNullOrEmpty(versionAttr)) Version = int.Parse(versionAttr);
            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            categories = new Dictionary<string, LocaleCategory>();
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
        System.Xml.Schema.XmlSchema? IXmlSerializable.GetSchema() => null;

        /// <summary>
        ///   <para>Returns the value of an entry with the specified <paramref name="name"/> in the specified <paramref name="category"/>, if found; otherwise, <see langword="null"/>.</para>
        /// </summary>
        /// <param name="category">The category to look for the entry in.</param>
        /// <param name="name">The name of the entry to look for.</param>
        /// <returns>The value of an entry with the specified <paramref name="name"/> in the specified <paramref name="category"/>, if found; otherwise, <see langword="null"/>.</returns>
        public string? this[string category, string name]
            => categories is not null && categories.TryGetValue(category, out LocaleCategory? cat) ? cat[name] : null;
    }
}
