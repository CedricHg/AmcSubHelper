using AmcSubHelper.Models;
using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Windows.Threading;

namespace AmcSubHelper.Logic
{
    internal class SoundHandler : IDisposable
    {
        private WaveOutEvent _outputDevice;
        private VorbisWaveReader _vorbisReader;
        private DispatcherTimer _playTimer;
        
        public bool IsPlaying { get; private set; }
        public TimeSpan TotalTime =>  _vorbisReader == null ? default(TimeSpan) : _vorbisReader.TotalTime;

        public event EventHandler<AudioPosition> PositionChanged;

        public static SoundHandler CreateFromPath(string soundFilePath)
        {
            var result = new SoundHandler
            {
                _outputDevice = new WaveOutEvent(),
                _vorbisReader = new VorbisWaveReader(soundFilePath),
                _playTimer = new DispatcherTimer()
            };

            result._playTimer.Interval = TimeSpan.FromMilliseconds(1);
            result._playTimer.Tick += result.PlayTimer_Tick;

            result._outputDevice.Init(result._vorbisReader);

            return result;
        }

        public void Play()
        {
            _outputDevice.Play();
            _playTimer.Start();
            IsPlaying = true;
        }

        public void Pause()
        {
            _outputDevice?.Pause();
            _playTimer.Stop();
            int ms = (int)GetCurrentAudioPosition().PositionMs;
            IsPlaying = false;
        }

        public void Stop()
        {
            _outputDevice?.Stop();
            _playTimer.Stop();
            _vorbisReader.Position = 0;
            IsPlaying = false;
        }

        public AudioPosition GetCurrentAudioPosition()
        {
            var outputwf = _outputDevice.OutputWaveFormat;
            double ms = _vorbisReader.Position * 1000.0 / outputwf.BitsPerSample / outputwf.Channels * 8 / outputwf.SampleRate;
            return new AudioPosition(ms);
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            var curPos = GetCurrentAudioPosition();
            PositionChanged?.Invoke(this, curPos);
        }

        public void Dispose()
        {
            if (_outputDevice != null)
            {
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _outputDevice = null;
            }

            if (_vorbisReader != null)
            {
                _vorbisReader.Dispose();
                _vorbisReader = null;
            }

            if (_playTimer != null)
            {
                _playTimer.Stop();
                _playTimer.Tick -= PlayTimer_Tick;
                _playTimer = null;
            }
        }
    }
}
