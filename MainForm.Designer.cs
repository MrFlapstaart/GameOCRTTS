
namespace GameOCRTTS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ocrButton = new System.Windows.Forms.Button();
            this.ocrBox = new System.Windows.Forms.TextBox();
            this.speakButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.ocrBoxLabel = new System.Windows.Forms.Label();
            this.logBoxLabel = new System.Windows.Forms.Label();
            this.rawImage = new System.Windows.Forms.PictureBox();
            this.processedImage = new System.Windows.Forms.PictureBox();
            this.rawImageLabel = new System.Windows.Forms.Label();
            this.processedImageLabel = new System.Windows.Forms.Label();
            this.garbageButton = new System.Windows.Forms.Button();
            this.imageOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorSelect = new System.Windows.Forms.ColorDialog();
            this.distanceBar = new System.Windows.Forms.TrackBar();
            this.distanceBarLabel = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.selectColorButton = new System.Windows.Forms.Button();
            this.contextMenuGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIssues = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIssuesDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIssuesOCR = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIssuesTTS = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIssuesDontKnow = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIssuesOther = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuVersionCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.selectColorLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.voiceComboLabel = new System.Windows.Forms.Label();
            this.voiceCombo = new System.Windows.Forms.ComboBox();
            this.defaultdpiLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultdpiBar = new System.Windows.Forms.TrackBar();
            this.contextMenuLicense = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.rawImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBar)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultdpiBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ocrButton
            // 
            this.ocrButton.Location = new System.Drawing.Point(15, 12);
            this.ocrButton.Name = "ocrButton";
            this.ocrButton.Size = new System.Drawing.Size(89, 23);
            this.ocrButton.TabIndex = 0;
            this.ocrButton.Text = "Test OCR...";
            this.ocrButton.UseVisualStyleBackColor = true;
            this.ocrButton.Click += new System.EventHandler(this.ocrButton_Click);
            // 
            // ocrBox
            // 
            this.ocrBox.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ocrBox.Location = new System.Drawing.Point(12, 57);
            this.ocrBox.Multiline = true;
            this.ocrBox.Name = "ocrBox";
            this.ocrBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ocrBox.Size = new System.Drawing.Size(450, 125);
            this.ocrBox.TabIndex = 1;
            this.ocrBox.Text = resources.GetString("ocrBox.Text");
            // 
            // speakButton
            // 
            this.speakButton.Location = new System.Drawing.Point(110, 12);
            this.speakButton.Name = "speakButton";
            this.speakButton.Size = new System.Drawing.Size(75, 23);
            this.speakButton.TabIndex = 2;
            this.speakButton.Text = "TTS";
            this.speakButton.UseVisualStyleBackColor = true;
            this.speakButton.Click += new System.EventHandler(this.speakButton_Click);
            // 
            // logBox
            // 
            this.logBox.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBox.Location = new System.Drawing.Point(12, 202);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(450, 120);
            this.logBox.TabIndex = 3;
            // 
            // ocrBoxLabel
            // 
            this.ocrBoxLabel.AutoSize = true;
            this.ocrBoxLabel.Location = new System.Drawing.Point(12, 38);
            this.ocrBoxLabel.Name = "ocrBoxLabel";
            this.ocrBoxLabel.Size = new System.Drawing.Size(88, 13);
            this.ocrBoxLabel.TabIndex = 4;
            this.ocrBoxLabel.Text = "Recognized Text";
            // 
            // logBoxLabel
            // 
            this.logBoxLabel.AutoSize = true;
            this.logBoxLabel.Location = new System.Drawing.Point(12, 185);
            this.logBoxLabel.Name = "logBoxLabel";
            this.logBoxLabel.Size = new System.Drawing.Size(25, 13);
            this.logBoxLabel.TabIndex = 5;
            this.logBoxLabel.Text = "Log";
            // 
            // rawImage
            // 
            this.rawImage.Location = new System.Drawing.Point(468, 57);
            this.rawImage.Name = "rawImage";
            this.rawImage.Size = new System.Drawing.Size(263, 125);
            this.rawImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rawImage.TabIndex = 6;
            this.rawImage.TabStop = false;
            // 
            // processedImage
            // 
            this.processedImage.Location = new System.Drawing.Point(464, 202);
            this.processedImage.Name = "processedImage";
            this.processedImage.Size = new System.Drawing.Size(263, 120);
            this.processedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.processedImage.TabIndex = 7;
            this.processedImage.TabStop = false;
            // 
            // rawImageLabel
            // 
            this.rawImageLabel.AutoSize = true;
            this.rawImageLabel.Location = new System.Drawing.Point(465, 38);
            this.rawImageLabel.Name = "rawImageLabel";
            this.rawImageLabel.Size = new System.Drawing.Size(61, 13);
            this.rawImageLabel.TabIndex = 8;
            this.rawImageLabel.Text = "Screenshot";
            // 
            // processedImageLabel
            // 
            this.processedImageLabel.AutoSize = true;
            this.processedImageLabel.Location = new System.Drawing.Point(465, 185);
            this.processedImageLabel.Name = "processedImageLabel";
            this.processedImageLabel.Size = new System.Drawing.Size(89, 13);
            this.processedImageLabel.TabIndex = 9;
            this.processedImageLabel.Text = "Processed Image";
            // 
            // garbageButton
            // 
            this.garbageButton.Location = new System.Drawing.Point(191, 12);
            this.garbageButton.Name = "garbageButton";
            this.garbageButton.Size = new System.Drawing.Size(109, 23);
            this.garbageButton.TabIndex = 10;
            this.garbageButton.Text = "Remove Garbage";
            this.garbageButton.UseVisualStyleBackColor = true;
            this.garbageButton.Click += new System.EventHandler(this.garbageButton_Click);
            // 
            // imageOpenDialog
            // 
            this.imageOpenDialog.Filter = "All Image Files (*.png, *.tiff, *.jpg, *.jpeg, *.bmp)|*.png;*.jpg;*.bmp;*.tiff;*." +
    "jpeg";
            // 
            // colorSelect
            // 
            this.colorSelect.AnyColor = true;
            // 
            // distanceBar
            // 
            this.distanceBar.Location = new System.Drawing.Point(740, 137);
            this.distanceBar.Maximum = 255;
            this.distanceBar.Name = "distanceBar";
            this.distanceBar.Size = new System.Drawing.Size(139, 45);
            this.distanceBar.TabIndex = 12;
            this.distanceBar.Value = 15;
            this.distanceBar.Scroll += new System.EventHandler(this.distanceBar_Scroll);
            // 
            // distanceBarLabel
            // 
            this.distanceBarLabel.AutoSize = true;
            this.distanceBarLabel.Location = new System.Drawing.Point(737, 121);
            this.distanceBarLabel.Name = "distanceBarLabel";
            this.distanceBarLabel.Size = new System.Drawing.Size(124, 13);
            this.distanceBarLabel.TabIndex = 13;
            this.distanceBarLabel.Text = "Text color fade distance:";
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.White;
            this.colorPanel.Location = new System.Drawing.Point(875, 85);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(23, 23);
            this.colorPanel.TabIndex = 14;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point(877, 142);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(13, 13);
            this.distanceLabel.TabIndex = 15;
            this.distanceLabel.Text = "0";
            // 
            // selectColorButton
            // 
            this.selectColorButton.Location = new System.Drawing.Point(740, 85);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(127, 23);
            this.selectColorButton.TabIndex = 16;
            this.selectColorButton.Text = "Select Text Color...";
            this.selectColorButton.UseVisualStyleBackColor = true;
            this.selectColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // contextMenuGitHub
            // 
            this.contextMenuGitHub.Name = "contextMenuGitHub";
            this.contextMenuGitHub.Size = new System.Drawing.Size(180, 22);
            this.contextMenuGitHub.Text = "GitHub page";
            this.contextMenuGitHub.Click += new System.EventHandler(this.contextMenuGitHub_Click);
            // 
            // contextMenuHelp
            // 
            this.contextMenuHelp.Name = "contextMenuHelp";
            this.contextMenuHelp.Size = new System.Drawing.Size(180, 22);
            this.contextMenuHelp.Text = "Help";
            this.contextMenuHelp.Click += new System.EventHandler(this.contextMenuHelp_Click);
            // 
            // contextMenuIssues
            // 
            this.contextMenuIssues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuIssuesDesign,
            this.contextMenuIssuesOCR,
            this.contextMenuIssuesTTS,
            this.contextMenuIssuesDontKnow,
            this.contextMenuIssuesOther});
            this.contextMenuIssues.Name = "contextMenuIssues";
            this.contextMenuIssues.Size = new System.Drawing.Size(180, 22);
            this.contextMenuIssues.Text = "Problems?";
            // 
            // contextMenuIssuesDesign
            // 
            this.contextMenuIssuesDesign.Name = "contextMenuIssuesDesign";
            this.contextMenuIssuesDesign.Size = new System.Drawing.Size(140, 22);
            this.contextMenuIssuesDesign.Text = "Design";
            this.contextMenuIssuesDesign.Click += new System.EventHandler(this.contextMenuIssuesDesign_Click);
            // 
            // contextMenuIssuesOCR
            // 
            this.contextMenuIssuesOCR.Name = "contextMenuIssuesOCR";
            this.contextMenuIssuesOCR.Size = new System.Drawing.Size(140, 22);
            this.contextMenuIssuesOCR.Text = "OCR";
            this.contextMenuIssuesOCR.Click += new System.EventHandler(this.contextMenuIssuesOCR_Click);
            // 
            // contextMenuIssuesTTS
            // 
            this.contextMenuIssuesTTS.Name = "contextMenuIssuesTTS";
            this.contextMenuIssuesTTS.Size = new System.Drawing.Size(140, 22);
            this.contextMenuIssuesTTS.Text = "TTS";
            this.contextMenuIssuesTTS.Click += new System.EventHandler(this.contextMenuIssuesTTS_Click);
            // 
            // contextMenuIssuesDontKnow
            // 
            this.contextMenuIssuesDontKnow.Name = "contextMenuIssuesDontKnow";
            this.contextMenuIssuesDontKnow.Size = new System.Drawing.Size(140, 22);
            this.contextMenuIssuesDontKnow.Text = "I don\'t know";
            this.contextMenuIssuesDontKnow.Click += new System.EventHandler(this.contextMenuIssuesDontKnow_Click);
            // 
            // contextMenuIssuesOther
            // 
            this.contextMenuIssuesOther.Name = "contextMenuIssuesOther";
            this.contextMenuIssuesOther.Size = new System.Drawing.Size(140, 22);
            this.contextMenuIssuesOther.Text = "Other";
            this.contextMenuIssuesOther.Click += new System.EventHandler(this.contextMenuIssuesOther_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuGitHub,
            this.contextMenuHelp,
            this.contextMenuIssues,
            this.contextMenuVersionCheck,
            this.contextMenuLicense,
            this.contextMenuAbout});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 158);
            // 
            // contextMenuVersionCheck
            // 
            this.contextMenuVersionCheck.Name = "contextMenuVersionCheck";
            this.contextMenuVersionCheck.Size = new System.Drawing.Size(180, 22);
            this.contextMenuVersionCheck.Text = "Live Update";
            this.contextMenuVersionCheck.Click += new System.EventHandler(this.contextMenuVersionCheck_Click);
            // 
            // contextMenuAbout
            // 
            this.contextMenuAbout.Name = "contextMenuAbout";
            this.contextMenuAbout.Size = new System.Drawing.Size(180, 22);
            this.contextMenuAbout.Text = "About";
            this.contextMenuAbout.Click += new System.EventHandler(this.contextMenuAbout_Click);
            // 
            // selectColorLabel
            // 
            this.selectColorLabel.AutoSize = true;
            this.selectColorLabel.Location = new System.Drawing.Point(737, 69);
            this.selectColorLabel.Name = "selectColorLabel";
            this.selectColorLabel.Size = new System.Drawing.Size(117, 13);
            this.selectColorLabel.TabIndex = 17;
            this.selectColorLabel.Text = "Text Balloon Font Color";
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Location = new System.Drawing.Point(737, 38);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(45, 13);
            this.settingsLabel.TabIndex = 18;
            this.settingsLabel.Text = "Settings";
            // 
            // voiceComboLabel
            // 
            this.voiceComboLabel.AutoSize = true;
            this.voiceComboLabel.Location = new System.Drawing.Point(737, 230);
            this.voiceComboLabel.Name = "voiceComboLabel";
            this.voiceComboLabel.Size = new System.Drawing.Size(37, 13);
            this.voiceComboLabel.TabIndex = 19;
            this.voiceComboLabel.Text = "Voice:";
            // 
            // voiceCombo
            // 
            this.voiceCombo.FormattingEnabled = true;
            this.voiceCombo.Location = new System.Drawing.Point(740, 247);
            this.voiceCombo.Name = "voiceCombo";
            this.voiceCombo.Size = new System.Drawing.Size(139, 21);
            this.voiceCombo.TabIndex = 20;
            // 
            // defaultdpiLabel
            // 
            this.defaultdpiLabel.AutoSize = true;
            this.defaultdpiLabel.Location = new System.Drawing.Point(877, 193);
            this.defaultdpiLabel.Name = "defaultdpiLabel";
            this.defaultdpiLabel.Size = new System.Drawing.Size(13, 13);
            this.defaultdpiLabel.TabIndex = 23;
            this.defaultdpiLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(737, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Default DPI";
            // 
            // defaultdpiBar
            // 
            this.defaultdpiBar.Location = new System.Drawing.Point(740, 188);
            this.defaultdpiBar.Maximum = 600;
            this.defaultdpiBar.Minimum = 50;
            this.defaultdpiBar.Name = "defaultdpiBar";
            this.defaultdpiBar.Size = new System.Drawing.Size(139, 45);
            this.defaultdpiBar.TabIndex = 21;
            this.defaultdpiBar.Value = 50;
            this.defaultdpiBar.Scroll += new System.EventHandler(this.defaultdpiBar_Scroll);
            // 
            // contextMenuLicense
            // 
            this.contextMenuLicense.Name = "contextMenuLicense";
            this.contextMenuLicense.Size = new System.Drawing.Size(180, 22);
            this.contextMenuLicense.Text = "License";
            this.contextMenuLicense.Click += new System.EventHandler(this.contextMenuLicense_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 334);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.defaultdpiLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.defaultdpiBar);
            this.Controls.Add(this.voiceCombo);
            this.Controls.Add(this.voiceComboLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.selectColorLabel);
            this.Controls.Add(this.selectColorButton);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.distanceBarLabel);
            this.Controls.Add(this.garbageButton);
            this.Controls.Add(this.processedImageLabel);
            this.Controls.Add(this.rawImageLabel);
            this.Controls.Add(this.processedImage);
            this.Controls.Add(this.rawImage);
            this.Controls.Add(this.logBoxLabel);
            this.Controls.Add(this.ocrBoxLabel);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.speakButton);
            this.Controls.Add(this.ocrBox);
            this.Controls.Add(this.ocrButton);
            this.Controls.Add(this.distanceBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Game OCR TTS";
            ((System.ComponentModel.ISupportInitialize)(this.rawImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBar)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.defaultdpiBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ocrButton;
        private System.Windows.Forms.TextBox ocrBox;
        private System.Windows.Forms.Button speakButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label ocrBoxLabel;
        private System.Windows.Forms.Label logBoxLabel;
        private System.Windows.Forms.PictureBox rawImage;
        private System.Windows.Forms.PictureBox processedImage;
        private System.Windows.Forms.Label rawImageLabel;
        private System.Windows.Forms.Label processedImageLabel;
        private System.Windows.Forms.Button garbageButton;
        private System.Windows.Forms.OpenFileDialog imageOpenDialog;
        private System.Windows.Forms.ColorDialog colorSelect;
        private System.Windows.Forms.TrackBar distanceBar;
        private System.Windows.Forms.Label distanceBarLabel;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.Button selectColorButton;
        private System.Windows.Forms.ToolStripMenuItem contextMenuGitHub;
        private System.Windows.Forms.ToolStripMenuItem contextMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIssues;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIssuesDesign;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIssuesOCR;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIssuesTTS;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIssuesDontKnow;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIssuesOther;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuVersionCheck;
        private System.Windows.Forms.ToolStripMenuItem contextMenuAbout;
        private System.Windows.Forms.Label selectColorLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label voiceComboLabel;
        private System.Windows.Forms.ComboBox voiceCombo;
        private System.Windows.Forms.Label defaultdpiLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar defaultdpiBar;
        private System.Windows.Forms.ToolStripMenuItem contextMenuLicense;
    }
}

