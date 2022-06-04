using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Storage
{
    public abstract class ActiveEntity :Entity
    {
        /// <summary>
        /// Признак активности объекта
        /// </summary>
        public bool Active { get; set; }
    }
}
