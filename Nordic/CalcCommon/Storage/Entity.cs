using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common.Storage
{
    /// <summary>
    /// Корневая сущность базы данных
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
