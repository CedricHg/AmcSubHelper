using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Vorbis;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AmcSubHelper
{
    // This code is gonna be messy cause I've barely worked with Winforms before and have never touched NAudio
    public partial class Form1 : Form
    {
        private string _selectedAudioFilePath;

        // For playback
        private WaveOutEvent outputDevice;
        private VorbisWaveReader _vorbisReader;

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

        private void playButton_Click(object sender, EventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                // TODO outputDevice.PlaybackStopped += OnPlaybackStopped;
            }

            if (_vorbisReader == null)
            {
                // For now, assume OGG file
                _vorbisReader = new NAudio.Vorbis.VorbisWaveReader(_selectedAudioFilePath);
                outputDevice.Init(_vorbisReader);
            }

            outputDevice.Play();
        }
    }
}
