using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

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

        /// <summary>
        /// Вывод комнаты в чат
        /// </summary>
        /// <param name="сlient">Клиент Telegram</param>
        /// <param name="id">Идентификатор чата</param>
        public void Show(ITelegramBotClient сlient, long id)
        {
            // Список кнопок
            var keys = Actions.Select(action => new KeyboardButton(action.Name));
            // Разметка для клавиатуры
            var markup = new ReplyKeyboardMarkup(keys)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
            сlient.SendTextMessageAsync(id, $"{Name}: {Description}", replyMarkup: markup);
        }
    }
}
