using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // [STAThread]
        static void Main()
        {
            // Application.SetHighDpiMode(HighDpiMode.SystemAware);
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);

            // Создание нового главного окна
            MainForm form = new MainForm();

            // Запуск приложения с заданным главным окном
            Application.Run(form);
        }
    }
}
