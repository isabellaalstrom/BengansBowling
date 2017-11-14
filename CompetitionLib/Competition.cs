using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;

namespace CompetitionLib
{
    public class Competition
    {
        public Guid CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public TimePeriod TimePeriod { get; set; }
        public List<Party> Players { get; set; }
        public List<Match> Matches { get; set; }
        public Sport Sport { get; set; }
    }
}
