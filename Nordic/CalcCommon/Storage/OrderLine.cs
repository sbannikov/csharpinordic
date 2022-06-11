using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common.Storage
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

        /// <summary>
        /// Цена материала
        /// </summary>
        public double Price => Material != null ? Material.Price : 0;

        /// <summary>
        /// Стоимость материала
        /// </summary>
        public double Summa => Amount * Price;
    }
}
