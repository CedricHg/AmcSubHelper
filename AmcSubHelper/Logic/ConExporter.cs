using AmcSubHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmcSubHelper.Logic
{
    internal static class ConExporter
    {
        public static void Export(string conFilePath, List<SubtitleTimeModel> subtitles)
        {
            StringBuilder conTextBuilder = new StringBuilder();

            for (int i = 0; i < subtitles.Count; i++)
            {
                string curLine = subtitles[i].Line.Replace("\"", string.Empty);
                int startAtTic = TimeToTicks(subtitles[i].Time);
                int? endAtTic = null;

                if (i <= subtitles.Count - 2)
                {
                    endAtTic = TimeToTicks(subtitles[i+1].Time);
                }

                if (i > 0)
                {
                    conTextBuilder.Append(Environment.NewLine);
                    conTextBuilder.Append("else ");
                }

                if (endAtTic.HasValue)
                {
                    conTextBuilder.Append($"ifge cs_timer {startAtTic} ifl cs_timer {endAtTic} {{");
                }
                else
                {
                    conTextBuilder.Append($"ifge cs_timer {startAtTic} {{");
                }

                // Expectation: lines are 140 characters max
                var lineLength = curLine.Length;
                var firstLine = curLine.Substring(0, lineLength <= 70 ? lineLength : 70);

                conTextBuilder.Append(Environment.NewLine);
                conTextBuilder.Append($"    qputs 350 {firstLine}");

                if (lineLength > 70)
                {
                    var secondLine = curLine.Substring(70);
                    conTextBuilder.Append(Environment.NewLine);
                    conTextBuilder.Append($"    qputs 351 {secondLine}");
                }

                conTextBuilder.Append(Environment.NewLine);
                conTextBuilder.Append("}");
            }

            File.WriteAllText(conFilePath, conTextBuilder.ToString());
        }

        private static int TimeToTicks(TimeSpan time)
        {
            // 30 tics = 1 second
            // Meaning, 0.03 tics = 1 millisecond.
            // Round down.
            return (int)Math.Floor(0.03 * time.TotalMilliseconds);
        }
    }
}
