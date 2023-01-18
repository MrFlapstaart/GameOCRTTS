using System.IO;
using System.Reflection;
using System.Net;
using System.Diagnostics;

namespace GameOCRTTS
{
    public class LiveUpdate
    {
        public string Product { get; private set; }
        public string TempDir { get; private set; }
        public string InstallerFileName { get; private set; }
        public string CurrentVersion { get; private set; }        
        public string LatestVersion { get; private set; }
        public string Repository { get; private set; }
               
        public LiveUpdate(string githubusername)
        {
            Product = Assembly.GetEntryAssembly().GetName().Name;
            TempDir = Path.GetTempPath() + Product + "\\";
            InstallerFileName = $"{TempDir}Installer.exe";

            Repository = $"{githubusername}/{Product}";

            string process = Assembly.GetEntryAssembly().Location;
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(process);
            CurrentVersion = $"{version.FileMajorPart}.{version.FileMinorPart}";
            NewerVersionAvailable();
        }

        public void CleanUpTemp()
        {                        
            // Remove temporary installer file.            
            if (File.Exists(InstallerFileName))
            {
                File.Delete(InstallerFileName);
            }
        }

        public bool NewerVersionAvailable()
        {
            // Send web request.
            var request = (HttpWebRequest)WebRequest.Create($"https://raw.githubusercontent.com/{Repository}/master/releases/LatestVersionNumber");
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            LatestVersion = responseString.Replace("\n","");

            return LatestVersion != CurrentVersion;
        }

        public void DownloadInstaller()
        {
            // Prepare temp folder
            Directory.CreateDirectory(TempDir);
            string LatestVersionCleaned = LatestVersion.Replace("\n", "");
            // Download installer
            WebClient webClient = new WebClient();
            webClient.DownloadFile($"https://github.com/{Repository}/releases/download/{LatestVersionCleaned}/Installer.exe", InstallerFileName);
        }
        
    }
}
