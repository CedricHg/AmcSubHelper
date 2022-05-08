using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmcSubHelper
{
    public partial class Form1 : Form
    {
        private string _selectedAudioFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void selectAudioFileMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedAudioFilePath = ofd.FileName;

                    selectedFileActualLabel.Text = _selectedAudioFilePath;
                }
            }
        }
    }
}
