using NAudio.Wave;

namespace SpeechRecognition
{
    public class Reader : ISound
    {
        private WaveFileReader reader;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя файла со звуком</param>
        public Reader(string name)
        {
            reader = new WaveFileReader(name);
        }

        /// <summary>
        /// Чтение звука из файла
        /// </summary>
        /// <returns></returns>
        public byte[] Sound()
        {
            byte[] sound = new byte[reader.Length];
            reader.Read(sound, 0, sound.Length);
            return sound;
        }

        /// <summary>
        /// Частота дискретизации в Гц
        /// </summary>
        public int SampleRate => reader.WaveFormat.SampleRate;
    }
}
