﻿using System;
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
                UpdateHandler.BotState.Dirty = true;
                room = value;
            }
        }
    }
}
