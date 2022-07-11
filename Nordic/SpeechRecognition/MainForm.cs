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
        private Recognizer recognizer;
       
        public MainForm()
        {
            InitializeComponent();
            recordingColor = recording.BackColor;
            recognizer = new Recognizer();
        }

        /// <summary>
        /// Нажата кнопка - начало записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recording_MouseDown(object sender, MouseEventArgs e)
        {
            recorder = new Recorder(FileName);
            recorder.Start();
            recording.BackColor = Color.OrangeRed;
        }

        private void recording_MouseUp(object sender, MouseEventArgs e)
        {
            recording.BackColor = recordingColor;
            recorder.Stop();
            text.Text = recognizer.Recognize(recorder);
            recorder = null;
        }

        private void reading_Click(object sender, EventArgs e)
        {
            var reader = new Reader(FileName);
            text.Text = recognizer.Recognize(reader);
        }
    }
}