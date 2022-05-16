using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot
{
    /// <summary>
    /// Прикладная ошибка бота
    /// </summary>
    public class BotException : Exception
    {
        /// <summary>
        /// Конструктор с сообщением
        /// </summary>
        /// <param name="message">Сообщение</param>
        public BotException(string message) : base(message)
        {
        }
    }
}
