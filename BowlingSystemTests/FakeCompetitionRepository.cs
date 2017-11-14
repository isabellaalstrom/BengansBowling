//using System;
//using System.Collections.Generic;
//using AccountabilityLib;
//using CompetitionInterfacesLib;
//using CompetitionLib;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace BowlingSystemUnitTests
//{
//    public class FakeCompetitionRepository : ICompetitionRepository
//    {
//        private List<Competition> _competitions = new List<Competition>();
//        private List<Match> _matches = new List<Match>();
//        private List<Round> _rounds = new List<Round>();
//        private List<Series> _series = new List<Series>();

//        public Guid Create(string name, TimePeriod timePeriod)
//        {
//            var competition = CompetitionFactory.Create(Sport.Bowling, name, timePeriod);
//            _competitions.Add(competition);
//            return competition.CompetitionId;
//        }

//        public List<Competition> ListCompetitions()
//        {
//            throw new NotImplementedException();
//        }

//        public bool RegisterCompetitionPlayer(Guid competitionId, Guid partyId)
//        {
//            throw new NotImplementedException();
//        }

//        public void RegisterMatchPoints(Guid matchId, int pointsOne, int pointsTwo)
//        {
//            throw new NotImplementedException();
//        }

//        public int GetWinnerOfYear(int year)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Party> ListPlayers(Guid competitionId)
//        {
//            return _competitions.FirstOrDefault(x => x.CompetitionId == competitionId).Players.ToList();

//        }

//        public List<Match> GenerateMatches(Guid competitionId)
//        {
//            var comp = _competitions.FirstOrDefault(x => x.CompetitionId == competitionId);
//            var compPlayers = ListPlayers(competitionId);
//            //todo add the generated matches to db
//            for (int i = 0; i < compPlayers.Count; i++)
//            {
//                if (i % 2 != 0) continue;
//                var playerOne = compPlayers[i];
//                var playerTwo = compPlayers[i + 1];
//                comp.Players.Add(playerOne);
//                comp.Players.Add(playerTwo);
//            }

//            return null;
//        }
//    }
//}
