using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using NLog;

namespace CSharpBot
{
    /// <summary>
    /// Обработчик событий от бота
    /// </summary>
    public class UpdateHandler : IUpdateHandler
    {
        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Состояние бота
        /// </summary>
        private static State state = State.Load<State>();

        /// <summary>
        /// Сценарий игры
        /// </summary>
        private Quest.Game game;

        /// <summary>
        /// Таймер сохранения состояния - 1 раз в секунду
        /// </summary>
        private Timer timer = new Timer(SaveState, null, 0, 1000);

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public UpdateHandler()
        {
            game = Quest.Game.Load<Quest.Game>();
            if (game.Rooms == null)
            {
                throw new BotException("Конфигурация игры не содержит комнат");
            }
        }

        /// <summary>
        /// Сохранение состояния по требованию
        /// </summary>
        /// <param name="state"></param>
        private static void SaveState(object o)
        {
            if (state.Dirty)
            {
                state.Save();
            }
        }

        /// <summary>
        /// Обработка ошибок
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            log.Warn(exception);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Обработка обновлений боту
        /// </summary>
        /// <param name="сlient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task HandleUpdateAsync(ITelegramBotClient сlient, Update update, CancellationToken cancellationToken)
        {
            // Поиск пользователя по идентификатору
            if (state.Users.TryGetValue(update.Message.Chat.Id, out User user))
            {
                // Фиксация последней активности пользователя
                user.TimeStamp = DateTime.Now;
                state.Dirty = true;
            }

            switch (update.Type)
            {
                case UpdateType.Message:
                    ProcessMessage(сlient, update.Message);
                    break;

                default:
                    string s = $"Обновления типа {update.Type} пока не обрабатываются";
                    сlient.SendTextMessageAsync(update.Message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Обработка сообщения
        /// </summary>
        /// <param name="message"></param>
        private void ProcessMessage(ITelegramBotClient сlient, Message message)
        {
            switch (message.Type)
            {
                case MessageType.Text:
                    if (message.Text[0] == '/')
                    {
                        ProcessCommand(сlient, message);
                    }
                    else
                    {
                        ProcessText(сlient, message);
                    }
                    break;

                default:
                    string s = $"Сообщения типа {message.Type} пока не обрабатываются";
                    сlient.SendTextMessageAsync(message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }
        }

        /// <summary>
        /// Обработка команды
        /// </summary>
        /// <param name="сlient"></param>
        /// <param name="message"></param>
        private void ProcessCommand(ITelegramBotClient сlient, Message message)
        {
            // Команда
            string command = message.Text.Substring(1).ToLower();
            User user;
            switch (command)
            {
                case "start":
                    if (!state.Users.ContainsKey(message.Chat.Id))
                    {
                        // Добавление пользователя в словарь
                        user = new User()
                        {
                            ID = message.Chat.Id
                        };
                        state.Users.Add(message.Chat.Id, user);
                        state.Dirty = true;
                        сlient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, я вас зарегистрировал");
                    }
                    else
                    {
                        сlient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, вы уже зарегистрированы");
                    }
                    break;

                case "play":
                    user = state.Users[message.Chat.Id];
                    int number; // номер комнаты
                    if (game.Rooms.ContainsKey(user.Room))
                    {
                        number = user.Room;
                    }
                    else
                    {
                        // начинаем с комнаты с минимальным номером
                        number = game.Rooms.Keys.Min(x => x);
                        user.Room = number;
                        state.Dirty = true;
                    }
                    Quest.Room room = game.Rooms[number];
                    var keys = room.Actions.Select(action => new KeyboardButton(action.Name));
                    var markup = new ReplyKeyboardMarkup(keys)
                    {
                        ResizeKeyboard = true,
                        OneTimeKeyboard = true
                    };
                    сlient.SendTextMessageAsync(message.Chat.Id, $"{room.Name}: {room.Description}", replyMarkup: markup);
                    break;

                case "help":
                    сlient.SendTextMessageAsync(message.Chat.Id, "Цель игры - разблокировать 12-й этаж", replyMarkup: null);
                    break;

                case "about":
                    сlient.SendTextMessageAsync(message.Chat.Id, "Учебный бот на C# - текстовый квест");
                    break;

                default:
                    string s = $"Команда {command} пока не обрабатываются";
                    сlient.SendTextMessageAsync(message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }
        }

        /// <summary>
        /// Обработка текста
        /// </summary>
        /// <param name="сlient"></param>
        /// <param name="message"></param>
        private void ProcessText(ITelegramBotClient сlient, Message message)
        {
            // обработка результата?
            сlient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, вы сказали мне: {message.Text}");
            log.Trace(message.Text);
        }
    }
}
