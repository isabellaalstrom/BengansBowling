using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionLib
{
    public class Round
    {
        public Guid RoundId { get; set; }

        public Guid PlayerOneSeriesId { get; set; }
        public Series PlayerOneSeries { get; set; }
        public Guid PlayerTwoSeriesId { get; set; }
        public Series PlayerTwoSeries { get; set; }
    }
}
