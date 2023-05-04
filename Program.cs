using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace GameOCRTTS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0 && args.Count(x => x.ToLower() == "-forceupdate") > 0)
            {

                var liveUpdater = new LiveUpdate(MainForm.GithubUsername);
                DialogResult dialogresult = MessageBox.Show("WARNING: The -forceupdate parameter should ONLY BE USED IF THERE IS AN ISSUE WITH THE LIVE UPDATER. It's for debugging purposes ONLY. Proceed with caution.", "-forceupdate parameter - WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.OK)
                {
                    if (liveUpdater.NewerVersionAvailable())
                    {
                        DialogResult dr = MessageBox.Show($"A newer version is available online. Download now?\n\n" +
                        $"Current version: {liveUpdater.CurrentVersion}\n" +
                        $"Latest version: {liveUpdater.LatestVersion}",
                        "Live update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            liveUpdater.DownloadInstaller();
                            Process.Start($"{liveUpdater.InstallerFileName}");
                        }
                    }
                }
                return;
            }
            Application.Run(new MainForm());
        }
    }
}
