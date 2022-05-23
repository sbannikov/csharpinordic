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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Признак нажатия левой кнопки мыши
        /// </summary>
        private bool mousePressed = false;

        /// <summary>
        /// Точка, где мышка была нажата
        /// </summary>
        private Point mouseDelta;

        /// <summary>
        /// Сценарий игры из файла JSON
        /// </summary>
        private Scenario.Game game;

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Пункт меню "Игра | Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Загрузка сценария
            game = Scenario.Game.Load<Scenario.Game>();

            // Начальное формирование кнопок
            foreach (string name in game.StartThings)
            {
                // Создаем кнопку
                var button = new Button()
                {
                    Content = name
                };
                button.Click += AddThing_Click;
                toolBar.Items.Add(button);
            }
        }

        private const int ThingWidth = 100;
        private const int ThingHeight = 100;

        /// <summary>
        /// Добавление нового предмета на поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void AddThing_Click(object sender, RoutedEventArgs e)
        {
            var rect = new Rectangle()
            {
                Height = ThingWidth,
                Width = ThingHeight,
                Fill = new SolidColorBrush(Colors.Navy)
            };

            // Обработчики для перемещения
            rect.MouseDown += Thing_MouseDown;
            rect.MouseUp += Thing_MouseUp;
            rect.MouseMove += Thing_MouseMove;

            // Устанавливаем в случайное место 
            Canvas.SetLeft(rect, random.Next(0, (int)(canvas.ActualWidth - ThingWidth)));
            Canvas.SetTop(rect, random.Next(0, (int)(canvas.ActualHeight - ThingHeight)));

            canvas.Children.Add(rect);
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Thing_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                Point point = e.GetPosition(canvas);
                Canvas.SetLeft((UIElement)sender, point.X - mouseDelta.X);
                Canvas.SetTop((UIElement)sender, point.Y - mouseDelta.Y);
            }
        }

        /// <summary>
        /// Фиксация отжатия левой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thing_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mousePressed = false;
        }

        /// <summary>
        /// Фиксация нажатия левой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousePressed = true;
            mouseDelta = e.GetPosition((UIElement)sender);
        }
    }
}
