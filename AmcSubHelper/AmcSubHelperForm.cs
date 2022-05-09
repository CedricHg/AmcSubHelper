using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using AmcSubHelper.Logic;
using AmcSubHelper.Models;
using NAudio.Vorbis;
using NAudio.Wave;

namespace AmcSubHelper
{
    // This code is gonna be messy cause I've barely worked with Winforms before and have never touched NAudio
    public partial class AmcSubHelperForm : Form
    {
        private SubProjectModel _projectModel = new SubProjectModel();

        // For playback
        private WaveOutEvent _outputDevice;
        private VorbisWaveReader _vorbisReader;
        private DispatcherTimer _playTimer;
        private bool _isPlaying;
        
        public AmcSubHelperForm()
        {
            this.Icon = new System.Drawing.Icon("0NfSOv.ico");
            InitializeComponent();

            playButton.Enabled = false;
            stopButton.Enabled = false;
        }

        private void selectAudioFileMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "OGG files (*.ogg)|*.ogg";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _projectModel.SoundFilePath = ofd.FileName;
                    HandleSoundImported(ofd.FileName);
                }
            }
        }

        private void selectSubtitleFileMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "TXT files (*.txt)|*.txt";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _projectModel.SubtitleFilePath = ofd.FileName;
                    HandleSubtitleFileImported(ofd.FileName);

                    var lines = File.ReadAllLines(ofd.FileName);
                    _projectModel.SubtitleTimings = lines.ToList()
                        .Select(x => new SubtitleTimeModel
                        {
                            Time = new TimeSpan(0,
                                0,
                                int.Parse(x.Substring(0, 2)),
                                int.Parse(x.Substring(3, 2)),
                                int.Parse(x.Substring(6, 3))),
                            Line = x.Substring(x.IndexOf('|') + 1)
                        })
                        .ToList();

                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!_isPlaying)
            {
                _outputDevice.Play();
                _playTimer.Start();
                _isPlaying = true;
                playButton.Text = "Pause";
                stopButton.Enabled = true;
            }
            else
            {
                _outputDevice?.Pause();
                _playTimer.Stop();
                int ms = (int)GetCurrentAudioPosition();
                soundProgressBar.Value = ms;
                var timespan = TimeSpan.FromMilliseconds(ms);
                currentTimeLabel.Text = FormatTimespan(timespan);
                _isPlaying = false;
                playButton.Text = "Play";
                stopButton.Enabled = true;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _outputDevice?.Stop();
            _playTimer.Stop();
            soundProgressBar.Value = 0;
            _vorbisReader.Position = 0;
            currentTimeLabel.Text = "00:00.000";
            currentSubtitleIndicatorLabel.Text = "";
            playButton.Text = "Play";
            _isPlaying = false;
            stopButton.Enabled = false;
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

            _projectModel.SubtitleTimings.ForEach(model =>
            {
                if (model.Time <= span)
                {
                    result = model.Line;
                }
            });

            return result;
        }

        private void saveProjectMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "AMC Subtitle project (*.amcsubproj)|*.amcsubproj";
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ProjectExportImport.ExportProject(sfd.FileName, _projectModel);
                }
            }   
        }

        private void openProjectMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "AMC Subtitle project (*.amcsubproj)|*.amcsubproj";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _projectModel = ProjectExportImport.OpenProject(ofd.FileName);

                    if (!string.IsNullOrWhiteSpace(_projectModel.SoundFilePath))
                    {
                        HandleSoundImported(_projectModel.SoundFilePath);
                        HandleSubtitleFileImported(_projectModel.SubtitleFilePath);
                    }
                }
            }
        }

        private void HandleSoundImported(string soundFilePath)
        {
            selectedFileActualLabel.Text = soundFilePath;

            if (_outputDevice != null)
            {
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _outputDevice = null;
            }

            _outputDevice = new WaveOutEvent();

            if (_vorbisReader != null)
            {
                _vorbisReader.Dispose();
                _vorbisReader = null;
            }
            _vorbisReader = new VorbisWaveReader(soundFilePath);

            soundProgressBar.Value = 0;
            soundProgressBar.Maximum = (int)_vorbisReader.TotalTime.TotalMilliseconds;
            totalTimeLabel.Text = FormatTimespan(_vorbisReader.TotalTime);
            currentTimeLabel.Text = "00:00.000";

            if (_playTimer != null)
            {
                _playTimer.Stop();
                _playTimer.Tick -= playTimer_Tick;
                _playTimer = null;
            }

            _playTimer = new DispatcherTimer();
            _playTimer.Interval = TimeSpan.FromMilliseconds(1);
            _playTimer.Tick += playTimer_Tick;

            _outputDevice.Init(_vorbisReader);

            playButton.Enabled = true;
        }

        private void HandleSubtitleFileImported(string subtitleFilePath)
        {
            selectedSubtitleFileText.Text = subtitleFilePath;
            currentSubtitleIndicatorLabel.Text = "";
        }
    }
}