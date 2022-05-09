namespace AmcSubHelper
{
    partial class Form1
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
            this.selectAudioFileMenuItem = new System.Windows.Forms.MenuItem();
            this.selectSubtitleFileMenuItem = new System.Windows.Forms.MenuItem();
            this.saveProjectMenuItem = new System.Windows.Forms.MenuItem();
            this.selectedfileLabel = new System.Windows.Forms.Label();
            this.selectedFileActualLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.soundProgressBar = new System.Windows.Forms.ProgressBar();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.slashLabel = new System.Windows.Forms.Label();
            this.currentSubtitleLabel = new System.Windows.Forms.Label();
            this.currentSubtitleIndicatorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedSubtitleFileText = new System.Windows.Forms.Label();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
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
            this.menuItem2,
            this.menuItem3,
            this.selectAudioFileMenuItem,
            this.selectSubtitleFileMenuItem,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.saveProjectMenuItem,
            this.menuItem7});
            this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.ShiftF1;
            this.menuItem1.Text = "File";
            // 
            // selectAudioFileMenuItem
            // 
            this.selectAudioFileMenuItem.Index = 1;
            this.selectAudioFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftA;
            this.selectAudioFileMenuItem.Text = "Import audio file";
            this.selectAudioFileMenuItem.Click += new System.EventHandler(this.selectAudioFileMenuItem_Click);
            // 
            // selectSubtitleFileMenuItem
            // 
            this.selectSubtitleFileMenuItem.Index = 2;
            this.selectSubtitleFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.selectSubtitleFileMenuItem.Text = "Import subtitle file";
            this.selectSubtitleFileMenuItem.Click += new System.EventHandler(this.selectSubtitleFileMenuItem_Click);
            // 
            // saveProjectMenuItem
            // 
            this.saveProjectMenuItem.Index = 3;
            this.saveProjectMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.saveProjectMenuItem.Text = "Save project";
            this.saveProjectMenuItem.Click += new System.EventHandler(this.saveProjectMenuItem_Click);
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
            // soundProgressBar
            // 
            this.soundProgressBar.Location = new System.Drawing.Point(16, 115);
            this.soundProgressBar.Name = "soundProgressBar";
            this.soundProgressBar.Size = new System.Drawing.Size(772, 23);
            this.soundProgressBar.TabIndex = 5;
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
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem2.Text = "Open project";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 5;
            this.menuItem5.Text = "Export CON script";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 8;
            this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuItem7.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectedSubtitleFileText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentSubtitleIndicatorLabel);
            this.Controls.Add(this.currentSubtitleLabel);
            this.Controls.Add(this.slashLabel);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.soundProgressBar);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.selectedFileActualLabel);
            this.Controls.Add(this.selectedfileLabel);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ProgressBar soundProgressBar;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label slashLabel;
        private System.Windows.Forms.Label currentSubtitleLabel;
        private System.Windows.Forms.Label currentSubtitleIndicatorLabel;
        private System.Windows.Forms.MenuItem selectSubtitleFileMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label selectedSubtitleFileText;
        private System.Windows.Forms.MenuItem saveProjectMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
    }
}