using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GameOCRTTS
{
    public partial class MainForm : Form
    {
        private KeyboardHook _Hook = new KeyboardHook();        
        private static readonly string GithubUsername = "MrFlapstaart";
        private LiveUpdate _LiveUpdater = new LiveUpdate(GithubUsername);
        private OCR _OCR = new OCR();

        public MainForm()
        {            
            // Register the event that is fired after the key press.
            _Hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Hook_KeyPressed);
            // Register hotkey for OCR/TTS. Oem3 = `
            _Hook.RegisterHotKey(SpecialKeys.None, Keys.Oem3);
            _Hook.RegisterHotKey(SpecialKeys.Control, Keys.Oem3);
            _Hook.RegisterHotKey(SpecialKeys.Shift, Keys.Oem3);

            InitializeComponent();

            colorPanel.BackColor = _OCR.Brightest;
            distanceBar.Value = _OCR.FadeDistance;
            distanceLabel.Text = _OCR.FadeDistance.ToString();

            defaultdpiBar.Value = _OCR.DefaultScaleDPI;
            defaultdpiLabel.Text = _OCR.DefaultScaleDPI.ToString();

            voiceCombo.Items.AddRange(TTS.GetVoices().ToArray());
            voiceCombo.SelectedIndex = 0;

            _LiveUpdater.CleanUpTemp();
            Text = $"{_LiveUpdater.Product} v{_LiveUpdater.CurrentVersion}";
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == SpecialKeys.Control)
            {
                Color color = ImageProc.GetColorFromCurrentPixel();
                SetTextColor(color);
                return;
            }
            else
            {
                Logger.Start();
                Logger.AddLog("Get active window boundaries.");
                Rectangle bounds = WinAPI.GetActiveWindowRect();
                Logger.AddLog("Capture screenshot.");
                Bitmap bitmap = ImageProc.CaptureScreenshot(bounds);

                ProcessImage(bitmap, e.Modifier == SpecialKeys.Shift);
            }
        }
                
        private void ocrButton_Click(object sender, EventArgs e)
        {
            if (imageOpenDialog.ShowDialog() != DialogResult.OK)
                return;
            
            Logger.Start();
            Logger.AddLog("Opening file");
            try
            {
                Image testimage = Bitmap.FromFile(imageOpenDialog.FileName);
                Bitmap bitmap = new Bitmap(testimage);
                ProcessImage(bitmap, false);
            }
            catch
            {
                Logger.AddLog($"Error opening image file, see https://github.com/MrFlapstaart/GameOCRTTS#error-opening-image-file");
                logBox.Text = Logger.Finish();
                MessageBox.Show("This is not a valid image file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void ProcessImage(Bitmap bitmap, bool forcefullscale)
        {                  
            OCRResult result = _OCR.HandleOCR(bitmap, forcefullscale);
            Image resultimage = result.ProcessedImage;            
            ocrBox.Text = result.ResultText;
            Logger.AddLog("Original text: " + result.OriginalText);
                        
            if (processedImage.Image != null)
                processedImage.Image.Dispose();
            try
            {
                processedImage.Image = new Bitmap(resultimage).Clone(
                    new Rectangle(result.Block.HPos, result.Block.VPos,
                    result.Block.Width == 1 ? resultimage.Width : result.Block.Width,
                    result.Block.Height == 1 ? resultimage.Height : result.Block.Height),
                    PixelFormat.DontCare);

                processedImageLabel.Text = $"Processed Image ({processedImage.Image.Width} x {processedImage.Image.Height})";
            }
            catch
            { }

            if (rawImage.Image != null)
                rawImage.Image.Dispose();
            rawImage.Image = bitmap.Clone(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                PixelFormat.DontCare);
            rawImageLabel.Text = $"Processed Image ({rawImage.Image.Width} x {rawImage.Image.Height})";

            Logger.AddLog("Reading out.");
            TTS.SpeakOut(ocrBox.Text?.Replace("\n", " "), voiceCombo.Text);
            if ((ocrBox.Text?.Trim()?.Length ?? 0) < 5)
                SFXPlayer.PlayError();

            Logger.AddLog("Done!");
            logBox.Text = Logger.Finish();

            //bitmap.Save(@"c:\temp\ocrraw.png", ImageFormat.Png);
            //resultimage.Save(@"c:\temp\ocrproc.png", ImageFormat.Png);
        }
                                                       
        private void speakButton_Click(object sender, EventArgs e)
        {
            TTS.SpeakOut(ocrBox.Text, voiceCombo.Text);
        }
                              
        private void garbageButton_Click(object sender, EventArgs e)
        {
            string text = TextHelper.StripSpecialCharacters(ocrBox.Text);
            ocrBox.Text = TextHelper.RemoveGarbageText(text);
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            colorSelect.Color = _OCR.Brightest;
            if (colorSelect.ShowDialog() != DialogResult.OK)
                return;

            SetTextColor(colorSelect.Color);
        }

        private void SetTextColor(Color color)
        {
            _OCR.Brightest = color;
            colorPanel.BackColor = _OCR.Brightest;
            string colorname = ImageProc.ColorToText(color);
            TTS.SpeakOut(colorname);            
        }

        private void distanceBar_Scroll(object sender, EventArgs e)
        {
            _OCR.FadeDistance = distanceBar.Value;
            distanceLabel.Text = _OCR.FadeDistance.ToString();
        }

        // Context menu links.
        private void contextMenuHelp_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/blob/master/README.md");
        }

        private void contextMenuGitHub_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}");
        }
        // Issue tracker links.
        private void contextMenuIssuesDesign_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/issues/new?assignees=MrFlapstaart&labels=design&template=design.md&title=");
        }

        private void contextMenuIssuesOCR_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/issues/new?assignees=MrFlapstaart&labels=ocr&template=ocr.md&title=");
        }

        private void contextMenuIssuesTTS_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/issues/new?assignees=MrFlapstaart&labels=tts&template=tts.md&title=");
        }

        private void contextMenuIssuesDontKnow_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/issues/new");
        }

        private void contextMenuIssuesOther_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/issues/new");
        }

        // End of issue tracker links.
        private void contextMenuVersionCheck_Click(object sender, EventArgs e)
        {            
            if (_LiveUpdater.NewerVersionAvailable())
            {
                // Show interactive MessageBox
                DialogResult dr = MessageBox.Show($"A newer version is available online. Download now?\n\n" +
                    $"Current version: {_LiveUpdater.CurrentVersion}\n" +
                    $"Latest version: {_LiveUpdater.LatestVersion}",
                          "Version Checker", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    // Run installer and close program.
                    _LiveUpdater.DownloadInstaller();
                    Process.Start($"{_LiveUpdater.InstallerFileName}");
                    Close();
                }
            }
            else
                MessageBox.Show("You have the latest version", "Version Checker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{_LiveUpdater.Product} version {_LiveUpdater.CurrentVersion} by @MrFlapstaart and @wrt54g", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void defaultdpiBar_Scroll(object sender, EventArgs e)
        {
            _OCR.DefaultScaleDPI = defaultdpiBar.Value;
            defaultdpiLabel.Text = defaultdpiBar.Value.ToString();
        }

        private void contextMenuLicense_Click(object sender, EventArgs e)
        {
            Process.Start($"https://github.com/{_LiveUpdater.Repository}/blob/master/LICENSE.md");
        }
        // End of context menu links.
    }
}