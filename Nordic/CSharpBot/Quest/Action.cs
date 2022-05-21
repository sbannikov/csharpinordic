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
        /// <summary>
        /// Команда при выборе действия
        /// </summary>
        public string Command;
        /// <summary>
        /// Условие для отображения команды
        /// </summary>
        public string Condition;

        /// <summary>
        /// Проверка выполнения условия для заданного игрока
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsCondition(User user)
        {
            return true;
        }
    }
}
