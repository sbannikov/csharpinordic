using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechRecognition
{
    public class BaseSound : ISound
    {
        byte[] sound;

        /// <summary>
        /// Звук в двоичном формате
        /// </summary>
        /// <returns></returns>
        public byte[] Sound()
        {
            return sound;
        }

        /// <summary>
        /// Частота дискретизации в Гц
        /// </summary>
        public int SampleRate { get; }

        public BaseSound(byte[] data, int rate)
        {
            sound = data;
            SampleRate = rate;
        }
    }
}
