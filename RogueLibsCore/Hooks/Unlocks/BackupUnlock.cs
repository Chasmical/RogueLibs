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
            xml.WriteAttributeString("N", UnlockName!);
            xml.WriteAttributeString("T", UnlockType!);
            xml.WriteAttributeString("U", Unlocked ? "1" : "0");
            xml.WriteAttributeString("D", NotActive ? "1" : "0");
            xml.WriteAttributeString("P", ProgressCount.ToString());
            foreach (string progress in ProgressList!)
                xml.WriteElementString("P", progress);
        }
        public void ReadXml(XmlReader xml)
        {
            UnlockName = xml.GetAttribute("N") ?? xml.GetAttribute("Name");
            UnlockType = xml.GetAttribute("T") ?? xml.GetAttribute("Type");
            string unlockedStr = xml.GetAttribute("U") ?? xml.GetAttribute("Unlocked")!;
            Unlocked = unlockedStr.Length is 1 ? unlockedStr == "1" : bool.Parse(unlockedStr);
            string notActiveStr = xml.GetAttribute("D") ?? xml.GetAttribute("NotActive")!;
            NotActive = notActiveStr.Length is 1 ? notActiveStr == "1" : bool.Parse(notActiveStr);
            ProgressCount = int.Parse(xml.GetAttribute("P") ?? xml.GetAttribute("ProgressCount")!);

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
