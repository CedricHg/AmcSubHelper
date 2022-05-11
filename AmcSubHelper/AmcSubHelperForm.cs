using AmcSubHelper.Logic;
using AmcSubHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AmcSubHelper
{
    // This code is gonna be messy cause I've barely worked with Winforms before and have never touched NAudio
    public partial class AmcSubHelperForm : Form
    {
        private SubProjectModel _projectModel = new SubProjectModel();
        private SoundHandler _soundHandler;
        
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
                    
                    var lines = File.ReadAllLines(ofd.FileName);
                    _projectModel.InitTimingsFromLines(lines);
                    HandleSubtitleFileImported(ofd.FileName, _projectModel.SubtitleTimings);
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!_soundHandler.IsPlaying)
            {
                playButton.Text = "Pause";
                stopButton.Enabled = true;
                _soundHandler?.Play();
            }
            else
            {
                playButton.Text = "Play";
                stopButton.Enabled = true;
                _soundHandler?.Pause();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _soundHandler?.Stop();
            soundProgressBar.Value = 0;
            currentTimeLabel.Text = "00:00.000";
            currentSubtitleIndicatorLabel.Text = "";
            playButton.Text = "Play";
            stopButton.Enabled = false;
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
                        HandleSubtitleFileImported(_projectModel.SubtitleFilePath, _projectModel.SubtitleTimings);
                    }
                }
            }
        }

        private void HandleSoundImported(string soundFilePath)
        {
            if (_soundHandler != null)
            {
                _soundHandler.PositionChanged -= SoundHandler_PositionChanged;
                _soundHandler.Dispose();
                _soundHandler = null;
            }

            _soundHandler = SoundHandler.CreateFromPath(soundFilePath);
            _soundHandler.PositionChanged += SoundHandler_PositionChanged;

            selectedFileActualLabel.Text = soundFilePath;
            soundProgressBar.Value = 0;
            soundProgressBar.Maximum = (int)_soundHandler.TotalTime.TotalMilliseconds;
            totalTimeLabel.Text = FormatTimespan(_soundHandler.TotalTime);
            currentTimeLabel.Text = "00:00.000";

            playButton.Enabled = true;
        }

        private void HandleSubtitleFileImported(string subtitleFilePath, List<SubtitleTimeModel> timings)
        {
            selectedSubtitleFileText.Text = subtitleFilePath;
            currentSubtitleIndicatorLabel.Text = "";

            subtitleFileTextBox.Text = string.Join(Environment.NewLine, timings
                .Select(t => t.ToString())
                .ToList());
        }

        private void subtitleFileTextBox_TextChanged(object sender, EventArgs e)
        {
            // Should probably figure out which line was changed exactly but this should perform fine anyway probably
            var lines = subtitleFileTextBox.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            _projectModel.InitTimingsFromLines(lines);
        }

        private void exportSubtitleFileMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(_projectModel.SubtitleFilePath, _projectModel.SubtitleTimings.Select(t => t.ToString()));
        }

        private void SoundHandler_PositionChanged(object sender, AudioPosition e)
        {
            soundProgressBar.Value = (int)e.PositionMs;
            currentTimeLabel.Text = e.ToString();
            currentSubtitleIndicatorLabel.Text = GetCurrentSubtitle(e.ToTimeSpan());
        }
    }
}