using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace Calculator.Common
{
    /// <summary>
    /// Базовый класс для файла JSON
    /// </summary>
    public abstract class JsonFile
    {
        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Признак необходимости сохранения состояния на диск
        /// </summary>
        internal bool Dirty = false;

        /// <summary>
        /// Загрузка состояния
        /// </summary>
        /// <returns></returns>
        public static T Load<T>() where T : new()
        {
            T entity;
            string name = null;
            try
            {
                // Краткое имя типа данных
                name = $"{typeof(T).Name}.json";
                // Чтение JSON-файла
                string json = System.IO.File.ReadAllText(name);
                // Десериализация в объект
                entity = JsonConvert.DeserializeObject<T>(json);
            }
            catch (System.IO.FileNotFoundException)
            {
                log.Warn($"Файл '{name}' не найден");
                entity = new T();
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                entity = new T();
            }
            return entity;
        }

        /// <summary>
        /// Загрузка объекта заданного типа
        /// </summary>
        /// <param name="type">Тип данных</param>
        /// <returns></returns>
        public static object Load(Type type)
        {
            object entity;
            string name = null;
            try
            {
                // Краткое имя типа данных
                name = $"{type.Name}.json";
                // Чтение JSON-файла
                string json = System.IO.File.ReadAllText(name);
                // Десериализация в объект
                entity = JsonConvert.DeserializeObject(json, type);
            }
            catch (System.IO.FileNotFoundException)
            {
                log.Warn($"Файл '{name}' не найден");
                // Создание объекта типа, заданного переменной
                entity = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                // Создание объекта типа, заданного переменной
                entity = Activator.CreateInstance(type);
            }
            return entity;
        }

        /// <summary>
        /// Сохранение объекта в формате JSON
        /// </summary>
        public void Save()
        {
            string name = $"{GetType().Name}.json";
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(this, settings);
            System.IO.File.WriteAllText(name, json);
            Dirty = false;
        }
    }
}
