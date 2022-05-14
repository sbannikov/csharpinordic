using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot.Quest
{
    public class Room
    {
        /// <summary>
        /// Уникальный номер комнаты
        /// </summary>
        public int Number;
        /// <summary>
        /// Название комнаты
        /// </summary>
        public string Name;
        /// <summary>
        /// Описание комнаты
        /// </summary>
        public string Description;
        /// <summary>
        /// Список возможных действий
        /// </summary>
        public List<Action> Actions;
    }
}
