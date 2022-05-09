using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public Material[] Materials;

        /// <summary>
        /// Сохранение в формате CSV
        /// </summary>
        /// <param name="name">Имя файла</param>
        public void SaveToCsv(string name)
        {
            // Открыть текстовый файл для записи, очистить, если файл уже был
            var file = new System.IO.StreamWriter(name);
            // [!] можно использовать Reflection
            file.WriteLine("Наименование;Цвет;Цена");

            foreach (var material in Materials)
            {
                file.WriteLine($"{material.Name};{material.ColorName};{material.Price}");
            }     
            // Закрыть файл в конце!
            file.Close();
        }

        public void SaveToXml(string name)
        {
        }

        public void SaveToJson(string name)
        {
        }
    }
}
