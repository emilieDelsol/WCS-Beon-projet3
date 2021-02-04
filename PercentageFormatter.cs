using System;
using System.Collections.Generic;
using System.Linq;

namespace BeOn
{
    public class PercentageFormatter
    {
        public Int32 Magnitude { get; set; }

        public PercentageFormatter(Int32 magnitude)
        {
            Magnitude = magnitude;
        }

        public IEnumerable<String> FormatMany(IEnumerable<Double> doubles)
        {
            foreach (Double ratio in doubles)
            {
                yield return Format(ratio);
            }
        }

        public String Format(Double ratio)
        {
            Double roundedRatio = Math.Floor(ratio * Magnitude);
            return roundedRatio.ToString();
        }
    }
}
