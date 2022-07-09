using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SpeechRecognition
{
    public class Recorder
    {
        private WaveIn waveIn;
        private WaveFileWriter writer;

        /// <summary>
        /// Подготовка к запиcи звука
        /// </summary>
        /// <param name="name">Имя файла для сохранения</param>
        public Recorder(string name)
        {
            // Объект для захвата звука
            waveIn = new WaveIn();
            // Дискретизация 8КГц, 1 канал звука
            waveIn.WaveFormat = new WaveFormat(8000, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.RecordingStopped += WaveIn_RecordingStopped;

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
        /// Обработка поступающих звуковых данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            // Запись фрагмента звука в выходной файл
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// Завершение записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_RecordingStopped(object? sender, StoppedEventArgs e)
        {
            writer.Close();
            writer = null;
            waveIn.Dispose();
            waveIn = null;
        }
    }
}
