using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Common.Storage
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public abstract class NamedEntity : ActiveEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [XmlAttribute()]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;
    }
}
