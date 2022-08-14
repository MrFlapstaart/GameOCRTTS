using System.Linq;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace GameOCRTTS
{
    internal static class TTS
    {
        private static SpeechSynthesizer _TTS = new SpeechSynthesizer();
                
        internal static void SpeakOut(string text)
        {
            SpeakOut(text, null);
        }

        internal static void SpeakOut(string text, string voicename)
        {
            _TTS.Dispose();
            if (string.IsNullOrEmpty(text))
                return;

            _TTS = new SpeechSynthesizer();
            _TTS.InjectOneCoreVoices();
            if (!string.IsNullOrEmpty(voicename))
                _TTS.SelectVoice(voicename);
            _TTS.SpeakAsync(text);
        }

        internal static List<string> GetVoices()
        {
            _TTS.InjectOneCoreVoices();
            var voicelist = _TTS.GetInstalledVoices();
            var result = voicelist.Select(x => x.VoiceInfo.Name).ToList();
            return result;
        }
    }
}
