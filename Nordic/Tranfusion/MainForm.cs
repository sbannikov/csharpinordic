namespace Tranfusion
{
    public partial class MainForm : Form
    {
        private Entities.Puzzle puzzle;

        public MainForm()
        {
            InitializeComponent();

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
                Controls.Add(control);
            }

            puzzle.Solve();
        }
    }
}