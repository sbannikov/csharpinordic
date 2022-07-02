using System.Linq;

namespace Tranfusion
{
    public partial class MainForm : Form
    {
        private Entities.Puzzle puzzle;

        private System.Windows.Forms.Timer timer;

        /// <summary>
        /// Очередь состояний для визуализации
        /// </summary>
        private Queue<Entities.State> queue = new Queue<Entities.State>();

        public MainForm()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            // Инициализация данных головоломки
            puzzle = new Entities.Puzzle();
            puzzle.Jars.Add(1, new Entities.Jar() { Number = 1, Size = 10 });
            puzzle.Jars.Add(2, new Entities.Jar() { Number = 2, Size = 5 });
            puzzle.Jars.Add(3, new Entities.Jar() { Number = 3, Size = 6 });
            puzzle.AddState(new Entities.State()
            {
                StateType = Enums.StateType.Start,
                Jars = new Dictionary<int, int?>() {
                    { 1, 10 },
                    { 2, 0 },
                    { 3, 0 }
                }
            });
            puzzle.AddState(new Entities.State()
            {
                StateType = Enums.StateType.Finish,
                Jars = new Dictionary<int, int?>() {
                    { 1, 8 },
                    { 2, null },
                    { 3, null }
                }
            });

            int max = puzzle.Jars.Values.Max(x => x.Size);
            foreach (var jar in puzzle.Jars)
            {
                var control = new JarControl(jar.Value.Size);
                control.Left = jar.Value.Number * 200;
                control.Top = (max - jar.Value.Size) * JarControl.HeightRatio;
                control.Tag = jar.Value.Number;
                panel.Controls.Add(control);
            }
        }

        /// <summary>
        /// Отображение решения головоломки покадрово
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (queue.TryDequeue(out Entities.State? state))
            {
                DrawState(state);
            }
            else
            {
                solveToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Отобразить состояние на экране
        /// </summary>
        /// <param name="state"></param>
        private void DrawState(Entities.State state)
        {
            foreach (JarControl jar in panel.Controls)
            {
                int number = (int)jar.Tag;
                int level = state.Jars[number].Value;
                jar.Level = level;
            }
        }

        /// <summary>
        /// Анимация решения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var turns = puzzle.Solve();
            queue.Enqueue(turns.First().FromState);

            foreach (var turn in turns)
            {
                queue.Enqueue(turn.ToState);
            }
            // Блокирование пункта меню
            solveToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Запуск логики после загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}