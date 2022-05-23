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
        /// Фигура, с которой мы соприкоснулись
        /// </summary>
        private Thing intersect;

        /// <summary>
        /// Сценарий игры из файла JSON
        /// </summary>
        private Scenario.Game game;

        /// <summary>
        /// Перекодировка категории в цвет
        /// </summary>
        private Dictionary<string, string> colors = new Dictionary<string, string>()
        {
            { "earth", "brown" },
            { "fire", "red" },
            { "water", "blue" },
            { "air", "lightblue" }
        };

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
                    Content = name,
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
            Button button = (Button)sender;
            string category = game.Things[(string)button.Content];
            string color = colors[category];

            var thing = new Thing((string)button.Content, color);


            // Обработчики для перемещения
            thing.MouseDown += Thing_MouseDown;
            thing.MouseUp += Thing_MouseUp;
            thing.MouseMove += Thing_MouseMove;

            // Устанавливаем в случайное место 
            Canvas.SetLeft(thing, random.Next(0, (int)(canvas.ActualWidth - ThingWidth)));
            Canvas.SetTop(thing, random.Next(0, (int)(canvas.ActualHeight - ThingHeight)));

            canvas.Children.Add(thing);
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
                Thing ui = (Thing)sender;

                double x1 = Canvas.GetLeft(ui);
                double x2 = Canvas.GetLeft(ui) + ui.ActualWidth;
                double y1 = Canvas.GetTop(ui);
                double y2 = Canvas.GetTop(ui) + ui.ActualHeight;

                // Проверка на пересечение с другими объектами
                Thing overlapped = null;
                foreach (Thing item in canvas.Children)
                {
                    // Пропуск себя самого
                    if (item == ui) continue;

                    double x1i = Canvas.GetLeft(item);
                    double x2i = Canvas.GetLeft(item) + item.ActualWidth;
                    double y1i = Canvas.GetTop(item);
                    double y2i = Canvas.GetTop(item) + item.ActualHeight;

                    // Проверка на пересечение по каждому из 4 углов
                    if ((x1 < x1i && x1i < x2 && y1 < y1i && y1i < y2) ||
                        (x1 < x2i && x2i < x2 && y1 < y1i && y1i < y2) ||
                        (x1 < x1i && x1i < x2 && y1 < y2i && y2i < y2) ||
                        (x1 < x2i && x2i < x2 && y1 < y2i && y2i < y2))
                    {
                        overlapped = item;
                        break;
                    }
                }

                if (overlapped != null) // нашли объект, с которым пересеклись
                {
                    // Если мы наехали на новый объект, не выехав с предыдущего
                    if ((intersect != overlapped) && (intersect != null))
                    {
                        // Предыдущий объект вернуть к черной рамке
                        intersect.Stroke = "black";
                    }
                    overlapped.Stroke = "red";
                    intersect = overlapped;
                }
                else if (intersect != null)
                { // не нашли, но ранее было пересечение
                    intersect.Stroke = "black";
                    intersect = null;
                }

                Point point = e.GetPosition(canvas);
                Canvas.SetLeft(ui, Math.Max(0, point.X - mouseDelta.X));
                Canvas.SetTop(ui, Math.Max(0, point.Y - mouseDelta.Y));
            }
        }

        /// <summary>
        /// Фиксация отжатия левой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thing_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Thing ui = (Thing)sender;

            mousePressed = false;
            if (intersect != null)
            {
                MessageBox.Show($"Вы соединяете {ui.Name} и {intersect.Name}");
            }
        }

        /// <summary>
        /// Фиксация нажатия левой кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement ui = (UIElement)sender;
            mousePressed = true;
            mouseDelta = e.GetPosition(ui);

            // Поиск максимального ZIndex
            int max = int.MinValue;
            foreach (UIElement item in canvas.Children)
            {
                int zIndex = Canvas.GetZIndex(item);
                max = Math.Max(max, zIndex);
            }

            Canvas.SetZIndex(ui, max + 1);
        }
    }
}
