using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Calculator.Common.Storage;
using Newtonsoft.Json;

namespace Calculator
{
    /// <summary>
    /// Данные, загружаемые из XML/JSON
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Перечень материалов
        /// </summary>
        [XmlElement(ElementName = "Material")]
        public RestAPI.Material[] Materials;

        /// <summary>
        /// Сохранение в формате CSV
        /// </summary>
        /// <param name="name">Имя файла</param>
        public void SaveToCsv(string name)
        {
            // Открыть текстовый файл для записи, очистить, если файл уже был
            using (var file = new System.IO.StreamWriter(name))
            {
                // [!] можно использовать Reflection
                file.WriteLine("Наименование;Цвет;Цена");

                foreach (var material in Materials)
                {
                    file.WriteLine($"{material.Name};{material.MaterialColor.Name};{material.Price}");
                }
            }
        }

        /// <summary>
        /// Сохранение в формате XML
        /// </summary>
        /// <param name="name"></param>
        public void SaveToXml(string name)
        {
            var serializer = new XmlSerializer(GetType());
            var settings = new System.Xml.XmlWriterSettings()
            {
                Indent = true // форматировать XML удобным для человека образом
            };
            using (var writer = System.Xml.XmlWriter.Create(name, settings))
            {
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Сохранение в формате JSON
        /// </summary>
        /// <param name="name"></param>
        /// Тест для GitHub
        public void SaveToJson(string name)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            System.IO.File.WriteAllText(name, json);
        }
    }
}
