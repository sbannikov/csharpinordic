namespace SpeechRecognition
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Имя файла для сохранения звука
        /// </summary>
        private const string FileName = @"C:\SOUND\TEST.WAV";

        private Color recordingColor;
        private Recorder? recorder;

        public MainForm()
        {
            InitializeComponent();
            recordingColor = recording.BackColor;
        }

        /// <summary>
        /// Нажата кнопка - начало записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recording_MouseDown(object sender, MouseEventArgs e)
        {
            recording.BackColor = Color.OrangeRed;
            recorder = new Recorder(FileName);
            recorder.Start();
        }

        private void recording_MouseUp(object sender, MouseEventArgs e)
        {
            recording.BackColor = recordingColor;
            recorder.Stop();
            recorder = null;
        }
    }
}