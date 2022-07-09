using NAudio.Wave;

namespace SpeechRecognition
{
    public class Recorder
    {
        private WaveIn waveIn;
        private WaveFileWriter writer;
        private string name;
        private List<byte> sound;

        /// <summary>
        /// Частота дискретизации в Гц
        /// </summary>
        public int SampleRate => waveIn.WaveFormat.SampleRate;

        /// <summary>
        /// Подготовка к запиcи звука
        /// </summary>
        /// <param name="name">Имя файла для сохранения</param>
        public Recorder(string name)
        {
            sound = new List<byte>();

            // Объект для захвата звука
            waveIn = new WaveIn();
            // Дискретизация 8КГц, 1 канал звука
            waveIn.WaveFormat = new WaveFormat(8000, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.RecordingStopped += WaveIn_RecordingStopped;

            // Запомнить имя файла
            this.name = name;
            // Объект для записи звука в файл
            writer = new WaveFileWriter(name, waveIn.WaveFormat);
        }

        /// <summary>
        /// Начало записи
        /// </summary>
        public void Start()
        {
            waveIn.StartRecording();
        }

        /// <summary>
        /// Останов записи
        /// </summary>
        public void Stop()
        {
            waveIn.StopRecording();
        }

        /// <summary>
        /// Массив байт со звуком внутри
        /// </summary>
        /// <returns></returns>
        public byte[] Sound()
        {
            return sound.ToArray();
        }

        /// <summary>
        /// Обработка поступающих звуковых данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            // Запись фрагмента звука в выходной файл
            writer.Write(e.Buffer, 0, e.BytesRecorded);
            // Запись фрагмента звука в список в памяти
            sound.AddRange(e.Buffer);
        }

        /// <summary>
        /// Завершение записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_RecordingStopped(object? sender, StoppedEventArgs e)
        {
            writer.Dispose();
            writer = null;
            waveIn.Dispose();
            waveIn = null;
        }
    }
}
