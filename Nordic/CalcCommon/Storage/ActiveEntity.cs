using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common.Storage
{
    public abstract class ActiveEntity : Entity
    {
        /// <summary>
        /// Признак активности объекта
        /// <para>По умолчанию каждый новый объект - активный</para>
        /// </summary>
        public bool Active { get; set; } = true;       
    }
}
