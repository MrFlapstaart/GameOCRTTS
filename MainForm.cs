using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace GameOCRTTS
{
    public partial class MainForm : Form
    {
        private KeyboardHook _Hook = new KeyboardHook();
        private Color _Brightest = Color.White;
        private int _FadeDistance = 15;
        private readonly string _VersionNumber = "1.2";

        public MainForm()
        {            
            // Register the event that is fired after the key press.
            _Hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Hook_KeyPressed);
            // Register hotkey for OCR/TTS. Oem3 = `
            _Hook.RegisterHotKey(SpecialKeys.None, Keys.Oem3);
            _Hook.RegisterHotKey(SpecialKeys.Control, Keys.Oem3);

            InitializeComponent();

            colorPanel.BackColor = _Brightest;
            distanceBar.Value = _FadeDistance;
            distanceLabel.Text = _FadeDistance.ToString();

            LiveUpdate.CleanUpTemp();
        }

        private void Hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == SpecialKeys.Control)
            {
                Color color = ImageProc.GetColorFromCurrentPixel();
                _Brightest = color;
                colorPanel.BackColor = color;
                SFXPlayer.PlayOK();
                return;
            }
            else
            {
                Logger.Start();
                Logger.AddLog("Get active window boundaries.");
                Rectangle bounds = WinAPI.GetActiveWindowRect();
                Logger.AddLog("Capture screenshot.");
                Bitmap bitmap = ImageProc.CaptureScreenshot(bounds);

                ProcessImage(bitmap);
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
                ProcessImage(bitmap);
            }
            catch
            {
                Logger.AddLog($"Error opening image file, see https://github.com/MrFlapstaart/GameOCRTTS#error-opening-image-file");
                logBox.Text = Logger.Finish();
                MessageBox.Show("This is not a valid image file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void ProcessImage(Bitmap bitmap)
        {
            Logger.AddLog("Rescaling image.");
            Image resultimage;
            if (bitmap.Width <= 1024)
                resultimage = ImageProc.Rescale(bitmap, 300, 300);
            else
                resultimage = ImageProc.Rescale(bitmap, 100, 100);

            Logger.AddLog("Stripping colors from image.");
            resultimage = ImageProc.StripColorsFromImage(resultimage, _Brightest, _FadeDistance);

            MemoryStream byteStream = new MemoryStream();
            Logger.AddLog("Converting to .tiff.");
            resultimage.Save(byteStream, System.Drawing.Imaging.ImageFormat.Tiff);
            byteStream.Position = 0;

            Logger.AddLog("Handle OCR.");
            // Multiple steps make it easier to debug.
            TextBlock block = OCR.GetTextFromTiffStream(byteStream.ToArray());
            string text = block.Text;
            string stripped = TextHelper.StripSpecialCharacters(text);
            ocrBox.Text = TextHelper.RemoveGarbageText(stripped);            
            using (Graphics g = Graphics.FromImage(resultimage))
            {
                var pen = new Pen(Color.Red);
                foreach (var line in block.Lines)
                {
                    g.DrawRectangle(pen, new Rectangle(line.HPos, line.VPos, line.Width, line.Height));
                }
            }

            if (processedImage.Image != null)
                processedImage.Image.Dispose();
            processedImage.Image = new Bitmap(resultimage).Clone(
                new Rectangle(block.HPos, block.VPos, 
                block.Width, block.Height),
                PixelFormat.DontCare);

            if (rawImage.Image != null)
                rawImage.Image.Dispose();
            rawImage.Image = bitmap.Clone(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                PixelFormat.DontCare);

            Logger.AddLog("Reading out.");
            TTS.SpeakOut(ocrBox.Text?.Replace("\n", " "));
            if ((ocrBox.Text?.Trim()?.Length ?? 0) < 5)
                SFXPlayer.PlayError();

            Logger.AddLog("Done!");
            logBox.Text = Logger.Finish();

            //bitmap.Save(@"c:\temp\ocrraw.png", ImageFormat.Png);
            //resultimage.Save(@"c:\temp\ocrproc.png", ImageFormat.Png);
        }
                                                       
        private void speakButton_Click(object sender, EventArgs e)
        {
            TTS.SpeakOut(ocrBox.Text);
        }
                              
        private void garbageButton_Click(object sender, EventArgs e)
        {
            string text = TextHelper.StripSpecialCharacters(ocrBox.Text);
            ocrBox.Text = TextHelper.RemoveGarbageText(text);
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            colorSelect.Color = _Brightest;
            if (colorSelect.ShowDialog() != DialogResult.OK)
                return;

            _Brightest = colorSelect.Color;
            colorPanel.BackColor = _Brightest;
        }

        private void distanceBar_Scroll(object sender, EventArgs e)
        {
            _FadeDistance = distanceBar.Value;
            distanceLabel.Text = _FadeDistance.ToString();
        }
        // Context menu links.
        private void contextMenuHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/blob/master/README.md");
        }

        private void contextMenuGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS");
        }
        // Issue tracker links.
        private void contextMenuIssuesDesign_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/issues/new?assignees=MrFlapstaart&labels=design&template=design.md&title=");
        }

        private void contextMenuIssuesOCR_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/issues/new?assignees=MrFlapstaart&labels=ocr&template=ocr.md&title=");

        }

        private void contextMenuIssuesTTS_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/issues/new?assignees=MrFlapstaart&labels=tts&template=tts.md&title=");
        }

        private void contextMenuIssuesDontKnow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/issues/new");
        }

        private void contextMenuIssuesOther_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrFlapstaart/GameOCRTTS/issues/new");
        }
        // End of issue tracker links.
        private void contextMenuVersionCheck_Click(object sender, EventArgs e)
        {
            LiveUpdate.DoWebRequest();
            string LatestVersionCleaned = LiveUpdate.LatestVersion.Replace("\n", "");
            if (_VersionNumber != LatestVersionCleaned)
            {
                // Show interactive MessageBox
                DialogResult dr = MessageBox.Show("A newer version is available online. Download now?",
                          "Version Checker", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    // Run installer and close program.
                    LiveUpdate.DownloadInstaller();
                    System.Diagnostics.Process.Start($"{LiveUpdate.INSTALLERFILENAME}");
                    Close();
                }
            }
            else
                MessageBox.Show("You have the latest version", "Version Checker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{LiveUpdate.PRODUCT} version {_VersionNumber} by @MrFlapstaart and @wrt54g", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // End of context menu links.
    }
}