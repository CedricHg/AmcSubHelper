using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Windows.Forms;
using System.Windows.Threading;

namespace AmcSubHelper
{
    // This code is gonna be messy cause I've barely worked with Winforms before and have never touched NAudio
    public partial class Form1 : Form
    {
        private string _selectedAudioFilePath;

        // For playback
        private WaveOutEvent _outputDevice;
        private VorbisWaveReader _vorbisReader;
        private DispatcherTimer _playTimer;
        private bool _stopped;

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

                    if (_outputDevice == null)
                    {
                        _outputDevice = new WaveOutEvent();
                        // TODO outputDevice.PlaybackStopped += OnPlaybackStopped;
                    }

                    _vorbisReader = new NAudio.Vorbis.VorbisWaveReader(_selectedAudioFilePath);
                    soundProgressBar.Maximum = (int)_vorbisReader.TotalTime.TotalMilliseconds;
                    totalTimeLabel.Text = FormatTimespan(_vorbisReader.TotalTime);
                    currentTimeLabel.Text = "00:00.000";

                    _playTimer = new DispatcherTimer();
                    _playTimer.Interval = TimeSpan.FromMilliseconds(1);
                    _playTimer.Tick += new EventHandler(playTimer_Tick);

                    _outputDevice.Init(_vorbisReader);
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            _outputDevice.Play();
            _playTimer.Start();
            _stopped = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            _outputDevice?.Pause();
            _playTimer.Stop();
            int ms = (int)GetCurrentAudioPosition();
            soundProgressBar.Value = ms;
            _stopped = true;
            var timespan = TimeSpan.FromMilliseconds(ms);
            currentTimeLabel.Text = FormatTimespan(timespan);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _outputDevice?.Stop();
            _playTimer.Stop();
            soundProgressBar.Value = 0;
            _stopped = true;
            _vorbisReader.Position = 0;
            currentTimeLabel.Text = "00:00.000";
        }

        private void playTimer_Tick(object sender, EventArgs e)
        {
            int ms = (int)GetCurrentAudioPosition();
            soundProgressBar.Value = ms;
            var timespan = TimeSpan.FromMilliseconds(ms);
            currentTimeLabel.Text = FormatTimespan(timespan);
        }

        private double GetCurrentAudioPosition()
        {
            var outputwf = _outputDevice.OutputWaveFormat;
            double ms = _vorbisReader.Position * 1000.0 / outputwf.BitsPerSample / outputwf.Channels * 8 / outputwf.SampleRate;
            return ms;
        }

        private string FormatTimespan(TimeSpan span)
        {
            return new DateTime(span.Ticks).ToString("mm:ss.fff");
        }
    }
}
