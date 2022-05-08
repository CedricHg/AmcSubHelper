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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}