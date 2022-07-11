using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace SpeechRecognition
{
    public class Player
    {
        private WaveOut waveOut;

        public Player()
        {
            waveOut = new WaveOut();
        }

        public void Play(ISound sound)
        {
            var ms = new MemoryStream(sound.Sound());
            var format = new WaveFormat(sound.SampleRate, 16, 1);
            IWaveProvider provider = new RawSourceWaveStream(ms, format);
            waveOut.Init(provider);
            waveOut.Play();
        }
    }
}
