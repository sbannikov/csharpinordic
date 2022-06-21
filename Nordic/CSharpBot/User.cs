using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot
{
    /// <summary>
    /// Пользователь Telegram
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long ID;

        /// <summary>
        /// Дата и время последней активности пользователя
        /// </summary>
        public DateTime TimeStamp;

        public DateTime timestamp
        {
            get
            {
                return TimeStamp;
            }
            set
            {
                if (UpdateHandler.BotState.Users != null)
                {
                    UpdateHandler.BotState.Dirty = true;
                }
                TimeStamp = value;
            }
        }

        /// <summary>
        /// Номер текущей комнаты
        /// </summary>
        private int room;


        /// <summary>
        /// Номер текущей комнаты
        /// </summary>
        public int Room
        {
            get
            {
                return room;
            }
            set
            {
                if (UpdateHandler.BotState != null)
                {
                    UpdateHandler.BotState.Dirty = true;
                }
                room = value;
            }
        }

        /// <summary>
        /// Переменные игры для пользователя
        /// </summary>
        public Dictionary<string, int> Variables = new Dictionary<string, int>();
    }
}
