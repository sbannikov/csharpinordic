using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Storage
{
    /// <summary>
    /// Материал
    /// </summary>
    public class Material : NamedEntity
    {
        /// <summary>
        /// Цвет в виде объекта
        /// </summary>
        // [XmlElement(ElementName = "Color")]
        [JsonIgnore()]
        [XmlIgnore()]
        public Color MaterialColor { get; set; }

        /// <summary>
        /// Наименование цвета
        /// </summary>
        [XmlAttribute(AttributeName = "Color")]
        [JsonProperty(PropertyName = "Color")]
        [NotMapped()] // не для базы данных
        public string ColorName { get; set; }

        /// <summary>
        /// Цена (руб. за м2)
        /// (цена может быть не задана)
        /// </summary>
        [XmlAttribute()]
        public double Price { get; set; }

        /// <summary>
        /// Строковое отображение объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {MaterialColor}";
        }
    }
}
