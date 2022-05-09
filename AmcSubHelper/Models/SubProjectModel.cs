using System.Collections.Generic;

namespace AmcSubHelper.Models
{
    internal class SubProjectModel
    {
        public string SoundFilePath { get; set; }

        public string SubtitleFilePath { get; set; }

        public List<SubtitleTimeModel> SubtitleTimings { get; set; }
    }
}
