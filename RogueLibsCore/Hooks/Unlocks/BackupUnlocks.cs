using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    internal class BackupUnlocks : IXmlSerializable
    {
        public int Nuggets { get; set; }
        private List<BackupUnlock>? unlocks;
        public List<BackupUnlock> Unlocks => unlocks ??= new List<BackupUnlock>();

        public BackupUnlock? Find(Unlock unlock)
            => unlocks?.Find(b => b.UnlockType == unlock.unlockType && b.UnlockName == unlock.unlockName);

        public void WriteXml(XmlWriter xml)
        {
            xml.WriteAttributeString("N", Nuggets.ToString());
            if (unlocks is not null)
                foreach (BackupUnlock unlock in unlocks)
                {
                    xml.WriteStartElement("B");
                    unlock.WriteXml(xml);
                    xml.WriteEndElement();
                }
        }
        public void ReadXml(XmlReader xml)
        {
            string? nuggetsAttr = xml.GetAttribute("N") ?? xml.GetAttribute("Nuggets");
            if (!string.IsNullOrEmpty(nuggetsAttr)) Nuggets = int.Parse(nuggetsAttr);

            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            unlocks = new List<BackupUnlock>();
            if (nonEmpty)
            {
                xml.MoveToContent();
                while (xml.NodeType != XmlNodeType.EndElement)
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        BackupUnlock unlock = new BackupUnlock();
                        unlock.ReadXml(xml);
                        unlocks.Add(unlock);
                    }
                    else xml.Skip();
                    xml.MoveToContent();
                }
                xml.ReadEndElement();
            }
        }
        System.Xml.Schema.XmlSchema? IXmlSerializable.GetSchema() => null;

    }
}
