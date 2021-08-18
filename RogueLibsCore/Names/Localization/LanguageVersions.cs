using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
	public sealed class LanguageVersions : IXmlSerializable
	{
		private LanguageVersions() { }
		public Dictionary<string, int> Entries { get; private set; }

		public void WriteXml(XmlWriter xml)
		{
			if (Entries != null)
				foreach (KeyValuePair<string, int> entry in Entries)
				{
					xml.WriteStartElement("Language");
					xml.WriteAttributeString("Id", entry.Key);
					xml.WriteAttributeString("Version", entry.Value.ToString());
					xml.WriteEndAttribute();
				}
		}
		public void ReadXml(XmlReader xml)
		{
			bool nonEmpty = !xml.IsEmptyElement;
			xml.ReadStartElement();
			Entries = new Dictionary<string, int>();
			if (nonEmpty)
			{
				xml.MoveToContent();
				while (xml.NodeType != XmlNodeType.EndElement)
				{
					if (xml.NodeType == XmlNodeType.Element)
					{
						string id = xml.GetAttribute("Id");
						string versionAttr = xml.GetAttribute("Version");
						Entries.Add(id, int.Parse(versionAttr));
					}
					xml.Skip();
					xml.MoveToContent();
				}
				xml.ReadEndElement();
			}

		}
		public System.Xml.Schema.XmlSchema GetSchema() => null;
	}
}
