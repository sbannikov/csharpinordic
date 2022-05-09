﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Calculator
{
    /// <summary>
    /// Материал
    /// </summary>
    public class Material : NamedEntity
    {
        /// <summary>
        /// Цвет в виде объекта
        /// </summary>
        [XmlElement(ElementName = "Color")]
        public Color MaterialColor;

        private string color;

        /// <summary>
        /// Наименование цвета
        /// </summary>
        [XmlAttribute(AttributeName = "Color")]
        [JsonProperty(PropertyName = "Color")]
        public string ColorName
        {
            get
            {
                return (MaterialColor != null) ? MaterialColor.Name : color;
            }
            set
            {
                color = value;
            }
        }

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
