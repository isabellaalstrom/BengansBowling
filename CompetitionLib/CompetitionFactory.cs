using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;

namespace CompetitionLib
{
    public class CompetitionFactory
    {
        public static Competition Create(Sport sport, string name, TimePeriod timePeriod)
        {
            if (sport == Sport.Bowling)
            {
                return new Competition
                {
                    Sport = Sport.Bowling,
                    CompetitionId = Guid.NewGuid(),
                    CompetitionName = name,
                    TimePeriod = timePeriod,
                    Players = new List<Party>(),
                    Matches = new List<Match>()
                };
            }
            return new Competition {Sport = Sport.Tennis, CompetitionId = Guid.NewGuid()};
        }
    }

    public enum Sport
    {
        Bowling,
        Tennis
    }
}
