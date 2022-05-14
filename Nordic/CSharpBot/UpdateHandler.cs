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
                    // обработка результата?
                    сlient.SendTextMessageAsync(message.Chat.Id, $"вы сказали мне: {message.Text}");
                    log.Trace(message.Text);
                    break;

                default:
                    string s = $"Сообщения типа {message.Type} пока не обрабатываются";
                    сlient.SendTextMessageAsync(message.Chat.Id, s);
                    log.Warn(s);
                    break;
            }
        }
    }
}
