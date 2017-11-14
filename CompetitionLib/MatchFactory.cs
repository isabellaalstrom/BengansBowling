using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionLib
{
    public class MatchFactory
    {
        public static Match Create(Guid playerOneId, Guid playerTwoId)
        {
            var match = new Match
            {
                MatchId = Guid.NewGuid(),
                Rounds = CreateRounds(),
                PlayerOneId = playerOneId,
                PlayerTwoId = playerTwoId
            };
            return match;
        }

        private static List<Round> CreateRounds()
        {
            var rounds = new List<Round>();

            for (int i = 0; i < 3; i++)
            {
                var s1 = CreateSeries();
                var s2 = CreateSeries();

                rounds.Add(new Round
                {
                    RoundId = Guid.NewGuid(),
                    PlayerOneSeries = s1,
                    PlayerOneSeriesId = s1.SeriesId,
                    PlayerTwoSeries = s2,
                    PlayerTwoSeriesId = s2.SeriesId
                });
            }
            return rounds;
        }

        private static Series CreateSeries()
        {
            return new Series
            {
                SeriesId = Guid.NewGuid()
            };
        }
    }
}