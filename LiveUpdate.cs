using System.IO;
using System.Reflection;
using System.Net;

namespace GameOCRTTS
{
    internal static class LiveUpdate
    {
        internal static readonly string PRODUCT = Assembly.GetEntryAssembly().GetName().Name;
        private static readonly string TEMPDIR = Path.GetTempPath() + PRODUCT + "\\";
        private static readonly string INSTALLERFILENAME = $"{TEMPDIR}Installer.exe";
        public static string LatestVersion = "";

        internal static void CleanUpTemp()
        {
            // Remove temporary installer file.            
            if (File.Exists(INSTALLERFILENAME))
            {
                File.Delete(INSTALLERFILENAME);
            }
        }
        internal static void DoWebRequest()
            {
                // Do web request
                var request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/MrFlapstaart/GameOCRTTS/master/releases/LatestVersionNumber");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                LatestVersion = responseString;
                // Remove enters
                // Check version number
            }
        internal static void DownloadInstaller()
        {
            string LatestVersionCleaned = LatestVersion.Replace("\n", "");
            // Create GameOCRTTS_Temp in C:\
            string dir = @"C:\GameOCRTTS_Temp\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            // Download installer
            WebClient webClient = new WebClient();
            webClient.DownloadFile($"https://github.com/MrFlapstaart/GameOCRTTS/releases/download/{LatestVersionCleaned}/Installer.exe", @"C:\GameOCRTTS_Temp\Installer.exe");
        }
        
    }
}
