using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOCRTTS
{
    internal static class Logger
    {
        private static StringBuilder _Log = null;
        private static DateTime _Started;

        internal static void Start()
        {
            _Started = DateTime.Now;
            _Log = new StringBuilder();
            AddLog("Started");
        }

        internal static void AddLog(string message)
        {
            if (_Log == null)
                Start();

            _Log.AppendLine($"{DateTime.Now.Subtract(_Started):hh\\:mm\\:ss\\:fff} {message}");
        }

        internal static string Finish()
        {
            string result = _Log?.ToString();
            _Log = null;
            return result;
        }
    }
}
