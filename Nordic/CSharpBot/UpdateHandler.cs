using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
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
        /// Словарь пользователей
        /// </summary>
        private Dictionary<long, User> users = new Dictionary<long, User>();

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
        /// Обработка сообщений боту
        /// </summary>
        /// <param name="сlient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task HandleUpdateAsync(ITelegramBotClient сlient, Update update, CancellationToken cancellationToken)
        {
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

            switch (command)
            {
                case "start":
                    if (!users.ContainsKey(message.Chat.Id))
                    {
                        // Добавление пользователя в словарь
                        var user = new User()
                        {
                            ID = message.Chat.Id
                        };
                        users.Add(message.Chat.Id, user);
                        сlient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, я вас зарегистрировал");
                    }
                    else
                    {
                        сlient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.FirstName}, вы уже зарегистрированы");
                    }
                    break;
                case "play":
                    // [!]
                    break;
                case "help":
                    сlient.SendTextMessageAsync(message.Chat.Id, "Цель игры - разблокировать 12-й этаж");
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
