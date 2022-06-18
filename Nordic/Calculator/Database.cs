using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common.Storage;
using MySql.Data.MySqlClient;
using NLog;

namespace Calculator
{ // Комментарий для теста GIT
    /// <summary>
    /// Методы для работы с базой данных
    /// </summary>
    public class Database : IEqualityComparer<Material>
    {
        /// <summary>
        /// Протоколирование событий
        /// </summary>
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private MySqlConnection connection;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Database()
        {
            // Конфигурация приложения
            var config1 = Common.Configuration.Load<Common.Configuration>();
           
            // Проверка на корректность настроек
            if (string.IsNullOrEmpty(config1.ConnectionString))
            {
                log.Warn("Строка соединения не задана в конфигурации");
            }
            
            // Создание соединения
            connection = new MySqlConnection();
            
            // Параметры соединения
            connection.ConnectionString = config1.ConnectionString;
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
        /// Сравнение материалов по имени
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Material? x, Material? y)
        {
            return (x != null) ? x.Name.Equals(y?.Name) : false;
        }

        /// <summary>
        /// Хэш объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetHashCode([DisallowNull] Material obj)
        {
            return obj.Name.GetHashCode();
        }

        /// <summary>
        /// Сохранение списка материалов в базу данных
        /// </summary>
        /// <param name="materials"></param>
        public int InsertMaterials(Material[] materials)
        {
            // Загрузка данных
            foreach (Material m in materials)
            {
                using (var command = connection.CreateCommand())
                {
                    // Проверка на наличие материала в БД
                    command.CommandText = "SELECT ID FROM Material WHERE Name = @name";
                    command.Parameters.AddWithValue("name", m.Name);
                    int? id = (int?)command.ExecuteScalar();
                    if (id == null)
                    {
                        // Добавление нового материала
                        command.CommandText = "INSERT INTO Material (Name, Color, Price) VALUES (@name, @color, @price)";
                        command.Parameters.AddWithValue("name", m.Name);
                        command.Parameters.AddWithValue("color", m.ColorName);
                        command.Parameters.AddWithValue("price", m.Price);
                    }
                    else
                    {
                        // Обновление существующего материала
                        command.CommandText = "UPDATE Material SET Color = @color, Price = @price WHERE ID = @id";
                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue("color", m.ColorName);
                        command.Parameters.AddWithValue("price", m.Price);
                    }
                    int result = command.ExecuteNonQuery();
                }
            }

            // Проверка на удалённые из файла материалы
            using (var command = connection.CreateCommand())
            {
                // Список всех материалов в базе данных
                List<Material> list = new List<Material>();

                command.CommandText = "SELECT ID, Name FROM Material";
                using (var reader = command.ExecuteReader())
                {
                    // Обработка всех строк таблицы - результата выполнения запроса
                    while (reader.Read())
                    {
                        Material m = new Material()
                        {
                            // [!] ID = reader.GetInt16("ID"),
                            Name = reader.GetString("Name")
                        };
                        list.Add(m);
                    }
                }

                // Список устаревших материалов
                var toDelete = list.Except(materials, this).ToList();

                foreach (var m in toDelete)
                {
                    command.CommandText = "UPDATE Material SET Active = 0 WHERE ID = @id";
                    command.Parameters.AddWithValue("id", m.ID);
                    command.ExecuteNonQuery();
                }
            }

            return materials.Count();
        }
    }
}
