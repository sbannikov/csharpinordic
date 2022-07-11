using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechRecognition
{
    /// <summary>
    /// Звук, который можно распознать
    /// </summary>
    public interface ISound
    {
        /// <summary>
        /// Звук в двоичном формате
        /// </summary>
        /// <returns></returns>
        byte[] Sound();

        /// <summary>
        /// Частота дискретизации в Гц
        /// </summary>
        int SampleRate { get; }
    }
}
