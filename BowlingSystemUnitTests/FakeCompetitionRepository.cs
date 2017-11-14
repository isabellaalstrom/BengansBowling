using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;
using CompetitionInterfacesLib;
using CompetitionLib;

namespace BowlingSystemUnitTests
{
    public class FakeCompetitionRepository : ICompetitionRepository
    {
        private List<Competition> _competitions = new List<Competition>();
        private List<Match> _matches = new List<Match>();
        private List<Round> _rounds = new List<Round>();
        private List<Series> _series = new List<Series>();

        public Guid Create(string name, TimePeriod timePeriod)
        {
            var competition = CompetitionFactory.Create(Sport.Bowling, name, timePeriod);
            _competitions.Add(competition);
            return competition.CompetitionId;
        }

        public List<Competition> ListCompetitions()
        {
            throw new NotImplementedException();
        }

        public void RegisterCompetitionPlayer(int competitionId, int partyId)
        {
            throw new NotImplementedException();
        }

        public List<Match> GenerateMatches()
        {
            throw new NotImplementedException();
        }

        public void RegisterMatchPoints(int matchId, int pointsOne, int pointsTwo)
        {
            throw new NotImplementedException();
        }

        public int GetWinnerOfYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
