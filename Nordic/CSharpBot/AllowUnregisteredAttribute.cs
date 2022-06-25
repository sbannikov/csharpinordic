using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot
{
    /// <summary>
    /// Допускается выполнение команды без регистрации пользователя
    /// </summary>
    public class AllowUnregisteredAttribute : Attribute
    {
        /// <summary>
        /// Разрешение выполнения команды без авторизации
        /// </summary>
        public bool Allow { get; set; } = true;
    }
}
