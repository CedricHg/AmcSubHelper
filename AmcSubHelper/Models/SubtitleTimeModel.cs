using System;

namespace AmcSubHelper.Models
{
    internal class SubtitleTimeModel
    {
        public TimeSpan Time { get; set; }
        public string Line { get; set; }

        public override string ToString()
        {
            return $"{Time.Minutes.ToString("D2")}:{Time.Seconds.ToString("D2")}.{Time.Milliseconds.ToString("D3")}|{Line}";
        }
    }
}
