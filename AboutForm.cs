using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOCRTTS
{
    public partial class AboutForm : Form
    {
        public string CurrentVersion { get; private set; }
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            string process = Assembly.GetEntryAssembly().Location;
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(process);
            CurrentVersion = $"{version.FileMajorPart}.{version.FileMinorPart}";
            versionLabel.Text = $"version {CurrentVersion}";
        }

        private void mrflapstaartLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/mrflapstaart");
        }

        private void wrt54gLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/wrt54g");
        }

        private void githubpageButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MrFlapstaart/GameOCRTTS");
        }

        private void readmeButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/blob/master/README.md");
        }

        private void changelogButton_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/MrFlapstaart/GameOCRTTS/blob/master/releases/{CurrentVersion}/CHANGELOG.md");
        }

        private void licenseButton_Click(object sender, EventArgs e)
        {
            LicenseForm licenseform = new LicenseForm();
            licenseform.Show();
        }
    }
}
