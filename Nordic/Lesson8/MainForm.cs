using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Количество очков, выпавшее на кости
        /// 0 - если броска еще не было
        /// </summary>
        int number = 0;

        Color color;


        Coordinate[] coordinates = new Coordinate[6]
        {
            new Coordinate(){ x=1,y=1},
            new Coordinate(){ x=1,y=2},
            new Coordinate(){ x=1,y=3},
            new Coordinate(){ x=2,y=1},
            new Coordinate(){ x=2,y=2},
            new Coordinate(){ x=2,y=3},
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            // Подтверждение броска кубика
            if (MessageBox.Show("Я сейчас брошу кубик", "Кубик",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Генератор случайных чисел
                var random = new Random();
                // Случайное число от 1 до 6
                number = random.Next(0, 6) + 1;
                // Вывести число в заголовок
                Text = $"Бросок: {number}";
                // Принудительная перерисовка панели
                panel.Invalidate();
            }
        }

        void DrawCircle(Graphics graphics, int x, int y)
        {
            Brush brush = new SolidBrush(Color.Navy);
            int dx = panel.Width / 12;
            int dy = panel.Height / 12;
            graphics.FillEllipse(brush, dx + 4 * dx * (x - 1), dy + 4 * dy * (y - 1), 2 * dx, 2 * dy);
        }

        /// <summary>
        /// Отрисовка панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (number > 0)
            {
                /*
                Pen pen = new Pen(Color.Navy);
                // окружность
                e.Graphics.DrawEllipse(pen, 1, 1, 100, 100);
                */

                /*
                for (int i = 0; i < number; i++)
                {
                    DrawCircle(e.Graphics, coordinates[i].x, coordinates[i].y);
                }
                */

                switch (number)
                {
                    case 1:
                        DrawCircle(e.Graphics, 2, 2);
                        break;
                    case 2:
                        DrawCircle(e.Graphics, 1, 1);
                        DrawCircle(e.Graphics, 3, 3);
                        break;
                    case 3:
                        DrawCircle(e.Graphics, 1, 1);
                        DrawCircle(e.Graphics, 2, 2);
                        DrawCircle(e.Graphics, 3, 3);
                        break;
                    case 4:
                        DrawCircle(e.Graphics, 1, 1);
                        DrawCircle(e.Graphics, 1, 3);
                        DrawCircle(e.Graphics, 3, 1);
                        DrawCircle(e.Graphics, 3, 3);
                        break;
                    case 5:
                        DrawCircle(e.Graphics, 1, 1);
                        DrawCircle(e.Graphics, 1, 3);
                        DrawCircle(e.Graphics, 2, 2);
                        DrawCircle(e.Graphics, 3, 1);
                        DrawCircle(e.Graphics, 3, 3);
                        break;
                    case 6:
                        DrawCircle(e.Graphics, 1, 1);
                        DrawCircle(e.Graphics, 1, 2);
                        DrawCircle(e.Graphics, 1, 3);
                        DrawCircle(e.Graphics, 3, 1);
                        DrawCircle(e.Graphics, 3, 2);
                        DrawCircle(e.Graphics, 3, 3);
                        break;
                }
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            panel.Invalidate();
        }

        private void buttonRoll_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            color = button.BackColor;
            buttonRoll.BackColor = Color.Coral;
        }

        private void buttonRoll_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = color;
        }
    }
}
