using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using AccountabilityLib;

namespace CompetitionLib
{
    public class Match
    {
        public Guid MatchId { get; set; }
        public Guid PlayerOneId { get; set; }
        public Party PlayerOne { get; set; }

        public int PlayerOnePoints
        {
            get { return Rounds.Sum(x => x.PlayerOneSeries.Score); }
        }

        public Guid PlayerTwoId { get; set; }
        public Party PlayerTwo { get; set; }

        public int PlayerTwoPoints
        {
            get { return Rounds.Sum(x => x.PlayerOneSeries.Score); }
        }

        public Guid WinnerId => PlayerOnePoints > PlayerTwoPoints ? PlayerOneId : PlayerTwoId;
        public List<Round> Rounds { get; set; }
        public Venue Asset { get; set; }
    }
}
