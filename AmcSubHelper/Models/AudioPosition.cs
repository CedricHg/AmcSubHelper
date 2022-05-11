using System;

namespace AmcSubHelper.Models
{
    internal class AudioPosition
    {
        public double PositionMs { get; }

        public AudioPosition(double positionMs)
        {
            if (positionMs < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(positionMs));
            }

            PositionMs = positionMs;
        }

        public override string ToString()
        {
            return new DateTime(ToTimeSpan().Ticks).ToString("mm:ss.fff");
        }

        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromMilliseconds(PositionMs);
        }
    }
}
