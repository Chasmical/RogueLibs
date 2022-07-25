using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace RogueLibsCore
{
    internal class BackupUnlock : IXmlSerializable
    {
        public void Store(Unlock unlock)
        {
            UnlockName = unlock.unlockName;
            UnlockType = unlock.unlockType;
            Unlocked = unlock.unlocked;
            NotActive = unlock.notActive;
            ProgressCount = unlock.progressCount;
            ProgressList = unlock.progressList;
        }
        public void Restore(Unlock unlock)
        {
            unlock.unlocked = Unlocked;
            unlock.notActive = NotActive;
            unlock.progressCount = ProgressCount;
            unlock.progressList = ProgressList?.ToList() ?? new List<string>();
        }

        public string? UnlockName;
        public string? UnlockType;
        public bool Unlocked;
        public bool NotActive;
        public int ProgressCount;
        public List<string>? ProgressList;
        public void WriteXml(XmlWriter xml)
        {
            xml.WriteAttributeString("Name", UnlockName!);
            xml.WriteAttributeString("Type", UnlockType!);
            xml.WriteAttributeString("Unlocked", Unlocked.ToString());
            xml.WriteAttributeString("NotActive", NotActive.ToString());
            xml.WriteAttributeString("ProgressCount", ProgressCount.ToString());
            foreach (string progress in ProgressList!)
                xml.WriteElementString("Progress", progress);
        }
        public void ReadXml(XmlReader xml)
        {
            UnlockName = xml.GetAttribute("Name");
            UnlockType = xml.GetAttribute("Type");
            Unlocked = bool.Parse(xml.GetAttribute("Unlocked")!);
            NotActive = bool.Parse(xml.GetAttribute("NotActive")!);
            ProgressCount = int.Parse(xml.GetAttribute("ProgressCount")!);

            bool nonEmpty = !xml.IsEmptyElement;
            xml.ReadStartElement();
            ProgressList = new List<string>();
            if (nonEmpty)
            {
                xml.MoveToContent();
                while (xml.NodeType != XmlNodeType.EndElement)
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        ProgressList.Add(xml.ReadElementContentAsString());
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
