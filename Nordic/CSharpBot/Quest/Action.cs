using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpBot.Quest
{
    public class Action
    {
        /// <summary>
        /// Название действия
        /// </summary>
        public string Name;
        /// <summary>
        /// Описание действия
        /// </summary>
        [XmlElement(ElementName = "Text")]
        public string Description;
        /// <summary>
        /// Номер комнаты, в которую перемещается игрок
        /// </summary>
        [XmlElement(ElementName = "Next")] 
        public int? Room;
    }
}
