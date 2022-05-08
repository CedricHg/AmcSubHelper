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
            this.selectedfileLabel = new System.Windows.Forms.Label();
            this.selectedFileActualLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.soundProgressBar = new System.Windows.Forms.ProgressBar();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.slashLabel = new System.Windows.Forms.Label();
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
            this.selectAudioFileMenuItem});
            this.menuItem1.Text = "File";
            // 
            // selectAudioFileMenuItem
            // 
            this.selectAudioFileMenuItem.Index = 0;
            this.selectAudioFileMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.selectAudioFileMenuItem.Text = "Select audio file";
            this.selectAudioFileMenuItem.Click += new System.EventHandler(this.selectAudioFileMenuItem_Click);
            // 
            // selectedfileLabel
            // 
            this.selectedfileLabel.AutoSize = true;
            this.selectedfileLabel.Location = new System.Drawing.Point(13, 13);
            this.selectedfileLabel.Name = "selectedfileLabel";
            this.selectedfileLabel.Size = new System.Drawing.Size(68, 13);
            this.selectedfileLabel.TabIndex = 0;
            this.selectedfileLabel.Text = "Selected file:";
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
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(98, 38);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(180, 39);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.slashLabel);
            this.Controls.Add(this.totalTimeLabel);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.soundProgressBar);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
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
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ProgressBar soundProgressBar;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label slashLabel;
    }
}