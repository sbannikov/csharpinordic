using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Description;
        /// <summary>
        /// Номер комнаты, в которую перемещается игрок
        /// </summary>
        public int? Room;
    }
}
