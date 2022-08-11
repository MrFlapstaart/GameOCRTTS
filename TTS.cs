﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace GameOCRTTS
{
    internal static class TTS
    {
        private static SpeechSynthesizer _TTS = new SpeechSynthesizer();

        public static void SpeakOut(string text)
        {
            _TTS.Dispose();
            if (string.IsNullOrEmpty(text))
                return;

            _TTS = new SpeechSynthesizer();
            //var voicelist = _TTS.GetInstalledVoices();
            //_TTS.SelectVoice(voicelist[0].VoiceInfo.Name);
            _TTS.SpeakAsync(text);
        }
    }
}
