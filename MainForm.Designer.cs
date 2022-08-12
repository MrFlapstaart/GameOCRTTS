
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
            ((System.ComponentModel.ISupportInitialize)(this.rawImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ocrButton
            // 
            this.ocrButton.Location = new System.Drawing.Point(29, 12);
            this.ocrButton.Name = "ocrButton";
            this.ocrButton.Size = new System.Drawing.Size(75, 23);
            this.ocrButton.TabIndex = 0;
            this.ocrButton.Text = "Test OCR...";
            this.ocrButton.UseVisualStyleBackColor = true;
            this.ocrButton.Click += new System.EventHandler(this.button1_Click);
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
            this.distanceBar.Location = new System.Drawing.Point(558, 12);
            this.distanceBar.Maximum = 100;
            this.distanceBar.Name = "distanceBar";
            this.distanceBar.Size = new System.Drawing.Size(142, 45);
            this.distanceBar.TabIndex = 12;
            this.distanceBar.Value = 15;
            this.distanceBar.Scroll += new System.EventHandler(this.distanceBar_Scroll);
            // 
            // distanceBarLabel
            // 
            this.distanceBarLabel.AutoSize = true;
            this.distanceBarLabel.Location = new System.Drawing.Point(475, 17);
            this.distanceBarLabel.Name = "distanceBarLabel";
            this.distanceBarLabel.Size = new System.Drawing.Size(77, 13);
            this.distanceBarLabel.TabIndex = 13;
            this.distanceBarLabel.Text = "Fade distance:";
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.White;
            this.colorPanel.Location = new System.Drawing.Point(439, 12);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(23, 23);
            this.colorPanel.TabIndex = 14;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point(706, 17);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(13, 13);
            this.distanceLabel.TabIndex = 15;
            this.distanceLabel.Text = "0";
            // 
            // selectColorButton
            // 
            this.selectColorButton.Location = new System.Drawing.Point(306, 12);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(127, 23);
            this.selectColorButton.TabIndex = 16;
            this.selectColorButton.Text = "Select Text Color...";
            this.selectColorButton.UseVisualStyleBackColor = true;
            this.selectColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 334);
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
    }
}

