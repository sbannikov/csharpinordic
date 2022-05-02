using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroTetris
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Интервал таймера игры
        /// </summary>
        private const int timerInterval = 1000;

        /// <summary>
        /// Фигуры
        /// </summary>
        List<Figure> figures;

        /// <summary>
        /// Таймер
        /// </summary>
        Timer timer;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            // Создание списка фигур
            figures = new List<Figure>();
            // Создание новой фигуры
            var figure = new Figure(panel.Width);
            figures.Add(figure);
            // Создание и настройка нового таймера
            timer = new Timer();
            timer.Interval = timerInterval; // время в миллисекундах
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Тик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Проверка, что фигура упала
            if (figures.Last().Down(panel.Height))
            {
                // Создание еще одной новой фигуры
                var figure = new Figure(panel.Width);
                figures.Add(figure);
            }
            panel.Invalidate(); // требование перерисовки
        }

        /// <summary>
        /// Перерисовка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figure in figures)
            {
                figure.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    timer.Interval = timerInterval / 10;
                    break;

                case Keys.Left:
                    if (figures.Last().Left())
                    {
                        panel.Invalidate(); // требование перерисовки
                    }
                    break;

                case Keys.Right:
                    if (figures.Last().Right())
                    {
                        panel.Invalidate(); // требование перерисовки
                    }
                    break;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    timer.Interval = timerInterval;
                    break;
            }
        }
    }
}
