using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Storage
{
    /// <summary>
    /// Строка заказа
    /// </summary>
    public class OrderLine : Entity
    {
        /// <summary>
        /// Материал
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// Количество материала
        /// </summary>
        public double Amount { get; set; }
    }
}
