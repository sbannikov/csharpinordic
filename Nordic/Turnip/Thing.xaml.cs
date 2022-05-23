using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Turnip
{
    /// <summary>
    /// Логика взаимодействия для Thing.xaml
    /// </summary>
    public partial class Thing : UserControl
    {
        /// <summary>
        /// Конструктор без параметров для дизайнера
        /// </summary>
        public Thing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Цвет рамки
        /// </summary>
        public string Stroke {
            set 
            {
                rect.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
            }
        }

        /// <summary>
        /// Имя предмета
        /// </summary>
        public new string Name
        {
            get 
            {                
                return (string)label.Content;
            }
        }

        /// <summary>
        /// Конструктор по имени
        /// </summary>
        /// <param name="name"></param>
        public Thing(string name, string color) : this()
        {
            label.Content = name;
            // Цвет формируется по строковому стандартному имени
            rect.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }
    }
}
