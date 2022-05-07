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
    }
}
