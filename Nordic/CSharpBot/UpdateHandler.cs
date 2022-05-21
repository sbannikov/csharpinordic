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
        internal static State BotState = State.Load<State>();

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
            if (BotState.Dirty)
            {
                BotState.Save();
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
        /// <param name="client"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            // Поиск пользователя по идентификатору
            if (BotState.Users.TryGetValue(update.Message.Chat.Id, out User user))
            {
                // Фиксация последней активности пользователя
                user.TimeStamp = DateTime.Now;
                BotState.Dirty = true;
            }

            switch (update.Type)
            {
                case UpdateType.Message:
                    ProcessMessage(client, update.Message);
                    break;

                default:
                    string s = $"Обновления типа {update.Type} пока не обрабатываются";
                    client.SendTextMessageAsync(update.Message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Обработка сообщения
        /// </summary>
        /// <param name="message"></param>
        private void ProcessMessage(ITelegramBotClient client, Message message)
        {
            switch (message.Type)
            {
                case MessageType.Text:
                    if (message.Text[0] == '/')
                    {
                        ProcessCommand(client, message);
                    }
                    else
                    {
                        ProcessText(client, message);
                    }
                    break;

                case MessageType.Sticker:
                    client.SendStickerAsync(message.Chat.Id, message.Sticker.FileId);
                    if (string.IsNullOrEmpty(message.Sticker.Emoji))
                    {
                        client.SendTextMessageAsync(message.Chat.Id, message.Sticker.Emoji);
                    }
                    break;

                default:
                    string s = $"Сообщения типа {message.Type} пока не обрабатываются";
                    client.SendTextMessageAsync(message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }
        }

        /// <summary>
        /// Обработка команды
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private void ProcessCommand(ITelegramBotClient client, Message message)
        {
            // Команда
            string command = message.Text.Substring(1).ToLower();
            User user;

            // Команда start выполняется для любого, в том числе и 
            // незарегистрированного пользователя
            if (command == "start")
            {
                if (!BotState.Users.ContainsKey(message.Chat.Id))
                {
                    // Добавление пользователя в словарь
                    user = new User()
                    {
                        ID = message.Chat.Id
                    };
                    BotState.Users.Add(message.Chat.Id, user);
                    BotState.Dirty = true;
                    client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, я вас зарегистрировал");
                }
                else
                {
                    client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, вы уже зарегистрированы");
                }
            }
            else
            {
                // Проверка на существование зарегистрированного пользователя
                if (!BotState.Users.ContainsKey(message.Chat.Id))
                {
                    client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, для начала работы надо зарегистрироваться при помощи команды /start");
                    return;
                }

                switch (command)
                {                   
                    case "reset": // Сброс игры
                        user = BotState.Users[message.Chat.Id];
                        // начинаем с комнаты с минимальным номером
                        user.Room = game.Rooms.Keys.Min(x => x);
                        break;

                    case "play":
                        user = BotState.Users[message.Chat.Id];
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
                        }
                        Quest.Room room = game.Rooms[number];
                        room.Show(client, message.Chat.Id);
                        break;

                    case "help":
                        client.SendTextMessageAsync(message.Chat.Id, "Цель игры - разблокировать 12-й этаж", replyMarkup: null);
                        break;

                    case "about":
                        client.SendTextMessageAsync(message.Chat.Id, "Учебный бот на C# - текстовый квест");
                        break;

                    default:
                        string s = $"Команда {command} пока не обрабатываются";
                        client.SendTextMessageAsync(message.Chat.Id, s);
                        log.Warn(s);
                        break;
                }
            }
        }

        /// <summary>
        /// Обработка текста
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private void ProcessText(ITelegramBotClient client, Message message)
        {
            log.Trace(message.Text);

            // Проверка на существование зарегистрированного пользователя
            if (!BotState.Users.ContainsKey(message.Chat.Id))
            {
                client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, для начала работы надо зарегистрироваться при помощи команды /start");
                return;
            }

            // Пользователь - игрок
            var user = BotState.Users[message.Chat.Id];
            // Поиск единственной комнаты по номеру из состояния игрока
            // Если комната не нашлась - null
            Quest.Room room = game.FindRoom(client, message.Chat.Id, user.Room);
            // Проверка на существование комнаты
            if (room == null)
            {
                return;
            }
            // Поиск действия в комнате по тексту
            // [!] надо сделать сравнение без учета регистра
            Quest.Action action = room.Actions.SingleOrDefault(x => x.Name == message.Text);
            // Проверка на существование действия
            if (action == null)
            {
                client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, действие {message.Text} отсутствует в комнате");
                return;
            }
            // Если у действия есть описание, отправим его игроку
            if (!string.IsNullOrEmpty(action.Description))
            {
                // ожидаем окончания отправки сообщения!
                client.SendTextMessageAsync(message.Chat.Id, action.Description).Wait();
            }
            // Если у действия задана комната, перейдем в эту комнату
            if (action.Room.HasValue)
            {
                user.Room = action.Room.Value;
                room = game.FindRoom(client, message.Chat.Id, user.Room);
                if (room == null) return;
            }
            // Показать комнату
            room.Show(client, message.Chat.Id);
        }
    }
}
