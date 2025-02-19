﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AmcSubHelper.Models
{
    internal class SubProjectModel
    {
        public string SoundFilePath { get; set; }

        public string SubtitleFilePath { get; set; }

        public List<SubtitleTimeModel> SubtitleTimings { get; set; }

        public void DefaultTiming()
        {
            SubtitleTimings = new List<SubtitleTimeModel>
            {
                new SubtitleTimeModel
                {
                    Time = new TimeSpan(0, 0, 0, 0, 0),
                    Line = string.Empty
                }
            };
        }

        public void InitTimingsFromLines(string[] lines)
        {
            SubtitleTimings = lines.ToList()
                .Select(x =>
                {
                    if (x.Length >= 9 && x.IndexOf("|") >= 0)
                    {
                        if (int.TryParse(x.Substring(0, 2), out int minutes)
                            && int.TryParse(x.Substring(3, 2), out int seconds)
                            && int.TryParse(x.Substring(6, 3), out int milliseconds))
                        {
                            return new SubtitleTimeModel
                            {
                                Time = new TimeSpan(0,
                                    0,
                                    minutes,
                                    seconds,
                                    milliseconds),
                                Line = x.Substring(x.IndexOf('|') + 1)
                            };
                        }
                    }

                    return null;
                })
                .Where(x => x != null)
                .OrderBy(x => x.Time)
                .ToList();
        }

        public void AddTime(TimeSpan time)
        {
            if (SubtitleTimings == null)
            {
                SubtitleTimings = new List<SubtitleTimeModel>();
            }

            SubtitleTimings.Add(new SubtitleTimeModel
            {
                Time = time,
                Line = string.Empty
            });

            SubtitleTimings = SubtitleTimings.OrderBy(x => x.Time).ToList();
        }
    }
}
