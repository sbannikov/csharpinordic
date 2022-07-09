using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NLog;

namespace SpeechRecognition
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
                // Информация о сборке (DLL)
                Assembly asm = Assembly.GetExecutingAssembly();
                // C:\GitHub\sbannikov\csharpnordic\Nordic\CalcRestAPI\bin\Debug\net5.0
                string path = System.IO.Path.GetDirectoryName(asm.Location);
                // Вариант: @$"{path}{System.IO.Path.PathSeparator}{name}";
                string fullName = System.IO.Path.Combine(path, name);
                // Чтение JSON-файла
                string json = System.IO.File.ReadAllText(fullName);
                // Десериализация в объект
                entity = JsonSerializer.Deserialize<T>(json);
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
                entity = JsonSerializer.Deserialize(json, type);
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
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(this, settings);
            System.IO.File.WriteAllText(name, json);
            Dirty = false;
        }
    }
}
