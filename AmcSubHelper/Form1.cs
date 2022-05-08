using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;

namespace AmcSubHelper
{
    // This code is gonna be messy cause I've barely worked with Winforms before and have never touched NAudio
    public partial class Form1 : Form
    {
        private string _selectedAudioFilePath;
        private string _selectedSubtitleFilePath;

        // For playback
        private WaveOutEvent _outputDevice;
        private VorbisWaveReader _vorbisReader;
        private DispatcherTimer _playTimer;

        // For subs
        private Dictionary<string, string> _timingsDict;

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

        private void selectSubtitleFileMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedSubtitleFilePath = ofd.FileName;
                    selectedSubtitleFileText.Text = _selectedSubtitleFilePath;
                    currentSubtitleIndicatorLabel.Text = "";

                    var lines = File.ReadAllLines(_selectedSubtitleFilePath);
                    _timingsDict = lines.ToList()
                        .Select(x => new
                        {
                            Time = x.Substring(0, x.IndexOf('|')),
                            Line = x.Substring(x.IndexOf('|') + 1)
                        })
                        .ToDictionary(x => x.Time, x => x.Line);
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            _outputDevice.Play();
            _playTimer.Start();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            _outputDevice?.Pause();
            _playTimer.Stop();
            int ms = (int)GetCurrentAudioPosition();
            soundProgressBar.Value = ms;
            var timespan = TimeSpan.FromMilliseconds(ms);
            currentTimeLabel.Text = FormatTimespan(timespan);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _outputDevice?.Stop();
            _playTimer.Stop();
            soundProgressBar.Value = 0;
            _vorbisReader.Position = 0;
            currentTimeLabel.Text = "00:00.000";
            currentSubtitleIndicatorLabel.Text = "";
        }

        private void playTimer_Tick(object sender, EventArgs e)
        {
            int ms = (int)GetCurrentAudioPosition();
            soundProgressBar.Value = ms;
            var timespan = TimeSpan.FromMilliseconds(ms);
            currentTimeLabel.Text = FormatTimespan(timespan);
            currentSubtitleIndicatorLabel.Text = GetCurrentSubtitle(timespan);
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

        private string GetCurrentSubtitle(TimeSpan span)
        {
            var result = string.Empty;

            foreach (var timestring in _timingsDict.Keys)
            {
                var colonIdx = timestring.IndexOf(':');
                var dotIdx = timestring.IndexOf('.');
                var minutes = int.Parse(timestring.Substring(0, 2));
                var seconds = int.Parse(timestring.Substring(colonIdx + 1, 2));
                var milliseconds = int.Parse(timestring.Substring(dotIdx + 1, 3));

                var checkspan = new TimeSpan(0, 0, minutes, seconds, milliseconds);

                if (checkspan <= span)
                {
                    result = _timingsDict[timestring];
                }
            }

            return result;
        }
    }
}
