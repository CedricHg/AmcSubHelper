using AmcSubHelper.Logic;
using AmcSubHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace AmcSubHelper
{
    // This code is gonna be messy cause I've barely worked with Winforms before and have never touched NAudio
    public partial class AmcSubHelperForm : Form
    {
        private SubProjectModel _projectModel;
        private SoundHandler _soundHandler;

        private bool soundTrackBarMouseDown = false;
        private bool unsavedChanges = false;
        private System.Windows.Forms.Timer soundImportedTrackbarDisableTimer;

        public AmcSubHelperForm()
        {
            this.Icon = new System.Drawing.Icon("0NfSOv.ico");
            InitializeComponent();

            NewProject();   
        }

        private void NewProject()
        {
            playButton.Enabled = false;
            stopButton.Enabled = false;
            rewindButton.Enabled = false;
            forwardButton.Enabled = false;
            soundProgressTrackBar.Enabled = false;

            selectedFileActualLabel.Text = string.Empty;
            soundProgressTrackBar.Value = 0;
            soundProgressTrackBar.Maximum = 0;
            totalTimeLabel.Text = "00:00.000";
            currentTimeLabel.Text = "00:00.000";

            selectedSubtitleFileText.Text = string.Empty;
            currentSubtitleIndicatorLabel.Text = String.Empty;

            _projectModel = new SubProjectModel();
            _projectModel.DefaultTiming();

            subtitleFileTextBox.Text = string.Join(Environment.NewLine, _projectModel.SubtitleTimings
                .Select(t => t.ToString())
                .ToList());
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
                    MarkUnsavedChanges(true);
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
                    MarkUnsavedChanges(true);
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = true;
            rewindButton.Enabled = true;
            forwardButton.Enabled = true;

            if (!_soundHandler.IsPlaying)
            {
                playButton.Text = "Pause";
                _soundHandler?.Play();
            }
            else
            {
                playButton.Text = "Play";
                _soundHandler?.Pause();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _soundHandler?.Stop();
            soundProgressTrackBar.Value = 0;
            currentTimeLabel.Text = "00:00.000";
            currentSubtitleIndicatorLabel.Text = "";
            playButton.Text = "Play";
            stopButton.Enabled = false;
            rewindButton.Enabled = false;
            forwardButton.Enabled = false;
        }

        private string FormatTimespan(TimeSpan span)
        {
            return new DateTime(span.Ticks).ToString("mm:ss.fff");
        }

        private string GetCurrentSubtitle(TimeSpan span)
        {
            var result = string.Empty;

            _projectModel?.SubtitleTimings?.ForEach(model =>
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
                    MarkUnsavedChanges(false);
                }
            }   
        }

        private void newProjectMenuItem_Click(object sender, EventArgs e)
        {
            if (unsavedChanges && WarnUnsavedChanges() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                NewProject();
                _soundHandler?.Dispose();
                _soundHandler = null;
                MarkUnsavedChanges(false);
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
                        MarkUnsavedChanges(false);
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
            soundProgressTrackBar.Value = 0;
            soundProgressTrackBar.Maximum = (int)_soundHandler.TotalTime.TotalMilliseconds;
            totalTimeLabel.Text = FormatTimespan(_soundHandler.TotalTime);
            currentTimeLabel.Text = "00:00.000";

            playButton.Enabled = true;

            // Heart attack prevention
            if (soundImportedTrackbarDisableTimer != null)
            {
                soundImportedTrackbarDisableTimer.Tick -= SoundImportedTrackbarDisableTimer_Tick;
                soundImportedTrackbarDisableTimer.Dispose();
                soundImportedTrackbarDisableTimer = null;
            }

            soundImportedTrackbarDisableTimer = new System.Windows.Forms.Timer();
            soundImportedTrackbarDisableTimer.Tick += SoundImportedTrackbarDisableTimer_Tick;
            soundImportedTrackbarDisableTimer.Interval = 1000;
            soundImportedTrackbarDisableTimer.Enabled = true;
        }

        private void SoundImportedTrackbarDisableTimer_Tick(object sender, EventArgs e)
        {
            soundProgressTrackBar.Enabled = true;
            (sender as System.Windows.Forms.Timer).Enabled = false;
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
            MarkUnsavedChanges(true);
        }

        private void SoundHandler_PositionChanged(object sender, AudioPosition e)
        {
            if (!soundTrackBarMouseDown)
            {
                soundProgressTrackBar.Value = (int)e.PositionMs;
                currentTimeLabel.Text = e.ToString();
                currentSubtitleIndicatorLabel.Text = GetCurrentSubtitle(e.ToTimeSpan());

                if (_soundHandler.TotalTime == e.ToTimeSpan())
                {
                    _soundHandler?.Stop();
                    soundProgressTrackBar.Value = 0;
                    currentTimeLabel.Text = "00:00.000";
                    currentSubtitleIndicatorLabel.Text = "";
                    playButton.Text = "Play";
                    stopButton.Enabled = false;
                    rewindButton.Enabled = false;
                    forwardButton.Enabled = false;
                }
            }
        }

        private void rewindButton_Click(object sender, EventArgs e)
        {
            _soundHandler?.RewindOneSec();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            _soundHandler?.ForwardOneSec();
        }

        private void soundProgressTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            soundTrackBarMouseDown = true;
            _soundHandler?.Pause();
        }

        private void soundProgressTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            soundTrackBarMouseDown = false;
            if (_soundHandler != null)
            {
                _soundHandler.Play();
                stopButton.Enabled = true;
                rewindButton.Enabled = true;
                forwardButton.Enabled = true;
                playButton.Text = "Pause";
            }
        }

        private void soundProgressTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (soundTrackBarMouseDown)
            {
                // Manually updating, value is in ms
                _soundHandler?.SetAtSec(soundProgressTrackBar.Value / 1000);

                var audioPos = new AudioPosition(soundProgressTrackBar.Value);
                currentTimeLabel.Text = audioPos.ToString();
                currentSubtitleIndicatorLabel.Text = GetCurrentSubtitle(audioPos.ToTimeSpan());
            }
        }

        private void conExportMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CON file (*.con)|*.con";
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ConExporter.Export(sfd.FileName, _projectModel.SubtitleTimings);
                    MessageBox.Show("CON File exported", "You did it", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MarkUnsavedChanges(bool hasUnsavedChanges)
        {
            var hadUnsavedChanges = unsavedChanges;

            unsavedChanges = hasUnsavedChanges;

            if (unsavedChanges && !hadUnsavedChanges)
            {
                Text += " - UNSAVED CHANGES";
            }
            else if (!unsavedChanges && hadUnsavedChanges)
            {
                Text = Text.Replace(" - UNSAVED CHANGES", string.Empty);
            }
        }

        private DialogResult WarnUnsavedChanges()
        {
            return MessageBox.Show(
                "Caution: you have unsaved changes.",
                "Unsaved changes",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
        }

        private void AmcSubHelperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                var dialogResult = WarnUnsavedChanges();

                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            if (!e.Cancel && _soundHandler != null)
            {
                _soundHandler.Dispose();
                _soundHandler = null;
            }
        }
    }
}