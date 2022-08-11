using WMPLib;

namespace GameOCRTTS
{
    internal class SFXPlayer
    {
        private static WindowsMediaPlayer _WMPlayer = new WindowsMediaPlayer();
        private static readonly string OKFILE = "ok.wav";
        private static readonly string ERRORFILE = "error.wav";

        public static void PlayOK()
        {
            _WMPlayer.URL = OKFILE;                        
            _WMPlayer.controls.play();
        }

        public static void PlayError()
        {            
            _WMPlayer.URL = ERRORFILE;
            _WMPlayer.controls.play();
        }
    }
}
