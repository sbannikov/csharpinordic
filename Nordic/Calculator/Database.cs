using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NLog;

namespace Calculator
{
    /// <summary>
    /// Методы для работы с базой данных
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Протоколирование событий
        /// </summary>
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private MySqlConnection connection;

        public Database()
        {
            // Конфигурация приложения
            var config = Configuration.Load<Configuration>();
            // Проверка на корректность настроек
            if (string.IsNullOrEmpty(config.ConnectionString))
            {
                log.Warn("Строка соединения не задана в конфигурации");
            }
            // Создание соединения
            connection = new MySqlConnection();
            // Параметры соединения
            connection.ConnectionString = config.ConnectionString;
        }

        /// <summary>
        /// Открытие соединения
        /// </summary>
        public void Connect()
        {
            connection.Open();
            log.Info("Соедиение с БД установлено");
        }

        /// <summary>
        /// Сохранение списка материалов в базу данных
        /// </summary>
        /// <param name="materials"></param>
        public void InsertMaterials(Material[] materials)
        {
            Material m = materials[0];

            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO Material (ID, Name, Color, Price) VALUES (2, '{m.Name}', '{m.ColorName}', {m.Price})";
            int result = command.ExecuteNonQuery();
        }
    }
}
