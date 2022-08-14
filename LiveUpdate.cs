﻿using System.IO;
using System.Reflection;
using System.Net;

namespace GameOCRTTS
{
    internal static class LiveUpdate
    {
        internal static readonly string PRODUCT = Assembly.GetEntryAssembly().GetName().Name;
        private static readonly string TEMPDIR = Path.GetTempPath() + PRODUCT + "\\";
        internal static readonly string INSTALLERFILENAME = $"{TEMPDIR}Installer.exe";
        internal static string LatestVersion = "";
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
            var request = (HttpWebRequest)WebRequest.Create($"https://raw.githubusercontent.com/{MainForm.Repository}/master/releases/LatestVersionNumber");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            LatestVersion = responseString;
        }

        internal static void DownloadInstaller()
        {
            string LatestVersionCleaned = LatestVersion.Replace("\n", "");
            // Download installer
            WebClient webClient = new WebClient();
            webClient.DownloadFile($"https://github.com/{MainForm.Repository}/releases/download/{LatestVersionCleaned}/Installer.exe", @$"{INSTALLERFILENAME}");
        }
        
    }
}
