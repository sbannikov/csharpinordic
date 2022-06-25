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
using System.Reflection;

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
                    DispatchMessage(client, update.Message);
                    break;

                default:
                    string s = $"Обновления типа {update.Type} пока не обрабатываются";
                    client.SendTextMessageAsync(update.Message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }

            return Task.CompletedTask;
        }

        private void ProcessSticker(ITelegramBotClient client, Message message)
        {
            client.SendStickerAsync(message.Chat.Id, message.Sticker.FileId);
            if (string.IsNullOrEmpty(message.Sticker.Emoji))
            {
                client.SendTextMessageAsync(message.Chat.Id, message.Sticker.Emoji);
            }
        }

        private void ProcessPhoto(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat.Id, $"Классная фотка, жаль, что не могу разглядеть детали");
        }

        /// <summary>
        /// Диспетчеризация сообщения
        /// </summary>
        /// <param name="message"></param>
        private void DispatchMessage(ITelegramBotClient client, Message message)
        {
            // Имя метода-обработчика
            string name = $"Process{message.Type}";

            // Получение метода-обработчика
            var type = this.GetType();
            var method = type.GetMethod(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (method == null)
            {
                string s = $"Сообщения типа {message.Type} пока не обрабатываются";
                client.SendTextMessageAsync(message.Chat.Id, s);
                log.Warn(s);
                return;
            }

            // Вызов метода с заданными параметрами
            method.Invoke(this, new object[] { client, message });
        }

        [AllowUnregistered(Allow = true)]       
        private void CommandStart(ITelegramBotClient client, Message message)
        {
            if (!BotState.Users.ContainsKey(message.Chat.Id))
            {
                // Добавление пользователя в словарь
                var user = new User()
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

        [AllowUnregistered]
        private void CommandAbout(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat.Id, "Учебный бот на C# - текстовый квест");
        }

        [AllowUnregistered]
        private void CommandHelp(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat.Id, "Цель игры - разблокировать 12-й этаж", replyMarkup: null);
        }

        [AllowUnregistered(Allow = false)]
        private void CommandPlay(ITelegramBotClient client, Message message)
        {
            var user = BotState.Users[message.Chat.Id];
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
        }

        private void CommandReset(ITelegramBotClient client, Message message)
        {
            var user = BotState.Users[message.Chat.Id];
            // начинаем с комнаты с минимальным номером
            user.Room = game.Rooms.Keys.Min(x => x);
            // Очистка пользовательских переменных
            user.Variables.Clear();
            client.SendTextMessageAsync(message.Chat.Id, "Состояние игры сброшено");
        }

        /// <summary>
        /// Обработка команды
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private void DispatchCommand(ITelegramBotClient client, Message message)
        {
            // Определение имени команды (отсекаем символ /)
            string command = message.Text.Substring(1);
            // Первый символ - прописной, остальные строчные
            command = command.Substring(0, 1).ToUpper() + command.Substring(1).ToLower();

            // Имя метода-обработчика
            // Commandstart
            string name = $"Command{command}";

            // Получение метода-обработчика
            var type = this.GetType();            
            var method = type.GetMethod(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (method == null)
            {
                string s = $"Команда типа {message.Text} пока не обрабатываются";
                client.SendTextMessageAsync(message.Chat.Id, s);
                log.Warn(s);
                return;
            }

            // Поиск конкретного атрибута метода
            var attr = method.GetCustomAttribute<AllowUnregisteredAttribute>();
            if (attr == null || !attr.Allow) // проверка регистрации пользователя
            {
                if (!BotState.Users.ContainsKey(message.Chat.Id))
                {
                    client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, для начала работы надо зарегистрироваться при помощи команды /start");
                    return;
                }
            }

            // Вызов метода с заданными параметрами
            method.Invoke(this, new object[] { client, message });
        }

        /// <summary>
        /// Обработка текста
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private void ProcessText(ITelegramBotClient client, Message message)
        {
            log.Trace(message.Text);

            // Проверка на команду
            if (message.Text[0] == '/')
            {
                DispatchCommand(client, message);
                return;
            }

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
            // [!] вернуть потом Single
            Quest.Action action = room.Actions.Where(x => x.IsCondition(user)).FirstOrDefault(x => x.Name == message.Text);
            // Проверка на существование действия
            if (action == null)
            {
                client.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, действие {message.Text} отсутствует в комнате");
                return;
            }
            // Выполнение команды
            action.DoCommand(user);
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
