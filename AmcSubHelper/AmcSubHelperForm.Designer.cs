namespace AmcSubHelper
{
    partial class AmcSubHelperForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.openProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.selectAudioFileMenuItem = new System.Windows.Forms.MenuItem();
            this.selectSubtitleFileMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.conExportMenuItem = new System.Windows.Forms.MenuItem();
            this.exportSubtitleFileMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.saveProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.selectedfileLabel = new System.Windows.Forms.Label();
            this.selectedFileActualLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.slashLabel = new System.Windows.Forms.Label();
            this.currentSubtitleLabel = new System.Windows.Forms.Label();
            this.currentSubtitleIndicatorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedSubtitleFileText = new System.Windows.Forms.Label();
            this.subtitleFileTextBox = new System.Windows.Forms.RichTextBox();
            this.rewindButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.soundProgressTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.soundProgressTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.openProjectMenuItem,
            this.menuItem3,
            this.selectAudioFileMenuItem,
            this.selectSubtitleFileMenuItem,
            this.menuItem4,
            this.conExportMenuItem,
            this.exportSubtitleFileMenuItem,
            this.menuItem6,
            this.saveProjectMenuItem,
            this.menuItem7});
            this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.ShiftF1;
            this.menuItem1.Text = "File";
            // 
            // openProjectMenuItem
            // 
            this.openProjectMenuItem.Index = 0;
            this.openProjectMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.openProjectMenuItem.Text = "Open project";
            this.openProjectMenuItem.Click += new System.EventHandler(this.openProjectMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // selectAudioFileMenuItem
            // 
            this.selectAudioFileMenuItem.Index = 2;
            this.selectAudioFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftA;
            this.selectAudioFileMenuItem.Text = "Import audio file";
            this.selectAudioFileMenuItem.Click += new System.EventHandler(this.selectAudioFileMenuItem_Click);
            // 
            // selectSubtitleFileMenuItem
            // 
            this.selectSubtitleFileMenuItem.Index = 3;
            this.selectSubtitleFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.selectSubtitleFileMenuItem.Text = "Import subtitle file";
            this.selectSubtitleFileMenuItem.Click += new System.EventHandler(this.selectSubtitleFileMenuItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // conExportMenuItem
            // 
            this.conExportMenuItem.Index = 5;
            this.conExportMenuItem.Text = "Export CON script";
            this.conExportMenuItem.Click += new System.EventHandler(this.conExportMenuItem_Click);
            // 
            // exportSubtitleFileMenuItem
            // 
            this.exportSubtitleFileMenuItem.Index = 6;
            this.exportSubtitleFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
            this.exportSubtitleFileMenuItem.Text = "Export subtitle file";
            this.exportSubtitleFileMenuItem.Click += new System.EventHandler(this.exportSubtitleFileMenuItem_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 7;
            this.menuItem6.Text = "-";
            // 
            // saveProjectMenuItem
            // 
            this.saveProjectMenuItem.Index = 8;
            this.saveProjectMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.saveProjectMenuItem.Text = "Save project";
            this.saveProjectMenuItem.Click += new System.EventHandler(this.saveProjectMenuItem_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 9;
            this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuItem7.Text = "Exit";
            // 
            // selectedfileLabel
            // 
            this.selectedfileLabel.AutoSize = true;
            this.selectedfileLabel.Location = new System.Drawing.Point(13, 13);
            this.selectedfileLabel.Name = "selectedfileLabel";
            this.selectedfileLabel.Size = new System.Drawing.Size(97, 13);
            this.selectedfileLabel.TabIndex = 0;
            this.selectedfileLabel.Text = "Selected audio file:";
            // 
            // selectedFileActualLabel
            // 
            this.selectedFileActualLabel.AutoSize = true;
            this.selectedFileActualLabel.Location = new System.Drawing.Point(88, 12);
            this.selectedFileActualLabel.Name = "selectedFileActualLabel";
            this.selectedFileActualLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedFileActualLabel.TabIndex = 1;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(16, 39);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseMnemonic = false;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(97, 39);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Location = new System.Drawing.Point(640, 96);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.currentTimeLabel.TabIndex = 6;
            this.currentTimeLabel.Text = "00:00.000";
            // 
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.Location = new System.Drawing.Point(733, 96);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.totalTimeLabel.TabIndex = 7;
            this.totalTimeLabel.Text = "00:00.000";
            // 
            // slashLabel
            // 
            this.slashLabel.AutoSize = true;
            this.slashLabel.Location = new System.Drawing.Point(701, 96);
            this.slashLabel.Name = "slashLabel";
            this.slashLabel.Size = new System.Drawing.Size(12, 13);
            this.slashLabel.TabIndex = 8;
            this.slashLabel.Text = "/";
            // 
            // currentSubtitleLabel
            // 
            this.currentSubtitleLabel.AutoSize = true;
            this.currentSubtitleLabel.Location = new System.Drawing.Point(13, 187);
            this.currentSubtitleLabel.Name = "currentSubtitleLabel";
            this.currentSubtitleLabel.Size = new System.Drawing.Size(80, 13);
            this.currentSubtitleLabel.TabIndex = 9;
            this.currentSubtitleLabel.Text = "Current subtitle:";
            // 
            // currentSubtitleIndicatorLabel
            // 
            this.currentSubtitleIndicatorLabel.AutoSize = true;
            this.currentSubtitleIndicatorLabel.Location = new System.Drawing.Point(19, 209);
            this.currentSubtitleIndicatorLabel.Name = "currentSubtitleIndicatorLabel";
            this.currentSubtitleIndicatorLabel.Size = new System.Drawing.Size(90, 13);
            this.currentSubtitleIndicatorLabel.TabIndex = 10;
            this.currentSubtitleIndicatorLabel.Text = "<no file selected>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected subtitle file:";
            // 
            // selectedSubtitleFileText
            // 
            this.selectedSubtitleFileText.AutoSize = true;
            this.selectedSubtitleFileText.Location = new System.Drawing.Point(123, 162);
            this.selectedSubtitleFileText.Name = "selectedSubtitleFileText";
            this.selectedSubtitleFileText.Size = new System.Drawing.Size(0, 13);
            this.selectedSubtitleFileText.TabIndex = 12;
            // 
            // subtitleFileTextBox
            // 
            this.subtitleFileTextBox.Location = new System.Drawing.Point(15, 241);
            this.subtitleFileTextBox.Name = "subtitleFileTextBox";
            this.subtitleFileTextBox.Size = new System.Drawing.Size(773, 197);
            this.subtitleFileTextBox.TabIndex = 13;
            this.subtitleFileTextBox.Text = "";
            this.subtitleFileTextBox.TextChanged += new System.EventHandler(this.subtitleFileTextBox_TextChanged);
            // 
            // rewindButton
            // 
            this.rewindButton.Location = new System.Drawing.Point(179, 38);
            this.rewindButton.Name = "rewindButton";
            this.rewindButton.Size = new System.Drawing.Size(92, 23);
            this.rewindButton.TabIndex = 14;
            this.rewindButton.Text = "Rewind 1 sec";
            this.rewindButton.UseVisualStyleBackColor = true;
            this.rewindButton.Click += new System.EventHandler(this.rewindButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(278, 39);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(104, 23);
            this.forwardButton.TabIndex = 15;
            this.forwardButton.Text = "Forward 1 sec";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // soundProgressTrackBar
            // 
            this.soundProgressTrackBar.Location = new System.Drawing.Point(16, 112);
            this.soundProgressTrackBar.Name = "soundProgressTrackBar";
            this.soundProgressTrackBar.Size = new System.Drawing.Size(772, 45);
            this.soundProgressTrackBar.TabIndex = 16;
            this.soundProgressTrackBar.ValueChanged += new System.EventHandler(this.soundProgressTrackBar_ValueChanged);
            this.soundProgressTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.soundProgressTrackBar_MouseDown);
            this.soundProgressTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.soundProgressTrackBar_MouseUp);
            // 
            // AmcSubHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.soundProgressTrackBar);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.rewindButton);
            this.Controls.Add(this.subtitleFileTextBox);
            this.Controls.Add(this.selectedSubtitleFileText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentSubtitleIndicatorLabel);
            this.Controls.Add(this.currentSubtitleLabel);
            this.Controls.Add(this.slashLabel);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.selectedFileActualLabel);
            this.Controls.Add(this.selectedfileLabel);
            this.Menu = this.mainMenu1;
            this.Name = "AmcSubHelperForm";
            this.Text = "AMC Subtitle Helper";
            ((System.ComponentModel.ISupportInitialize)(this.soundProgressTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem selectAudioFileMenuItem;
        private System.Windows.Forms.Label selectedfileLabel;
        private System.Windows.Forms.Label selectedFileActualLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label slashLabel;
        private System.Windows.Forms.Label currentSubtitleLabel;
        private System.Windows.Forms.Label currentSubtitleIndicatorLabel;
        private System.Windows.Forms.MenuItem selectSubtitleFileMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectedSubtitleFileText;
        private System.Windows.Forms.MenuItem saveProjectMenuItem;
        private System.Windows.Forms.MenuItem openProjectMenuItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem conExportMenuItem;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.RichTextBox subtitleFileTextBox;
        private System.Windows.Forms.MenuItem exportSubtitleFileMenuItem;
        private System.Windows.Forms.Button rewindButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.TrackBar soundProgressTrackBar;
    }
}