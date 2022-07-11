using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechRecognition
{
    abstract public class GenericSound
    {
        /// <summary>
        /// Звук в двоичном формате
        /// </summary>
        /// <returns></returns>
        abstract public byte[] Sound();

        /// <summary>
        /// Частота дискретизации в Гц
        /// </summary>
        virtual public int SampleRate { get; }
    }
}
