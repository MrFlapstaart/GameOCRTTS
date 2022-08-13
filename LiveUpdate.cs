using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace GameOCRTTS
{
    internal static class LiveUpdate
    {
        internal static readonly string PRODUCT = Assembly.GetEntryAssembly().GetName().Name;
        private static readonly string TEMPDIR = Path.GetTempPath() + PRODUCT + "\\";
        private static readonly string INSTALLERFILENAME = $"{TEMPDIR}Installer.exe";

        internal static void CleanUpTemp()
        {
            // Remove temporary installer file.            
            if (File.Exists(INSTALLERFILENAME))
            {
                File.Delete(INSTALLERFILENAME);
            }
        }
    }
}
