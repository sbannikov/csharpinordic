using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculator
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public class NamedEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [XmlAttribute()]
        public string Name;
    }
}
