using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountabilityLib;
using BowlingSystemInterfacesLib;
using CompetitionLib;

namespace BowlingSystemDbLib
{
    public class SqlBowlingRepository : IBowlingRepository
    {
        private readonly BowlingSystemContext _context;

        public SqlBowlingRepository(BowlingSystemContext context)
        {
            _context = context;
        }

        public Guid Create(string name, TimePeriod timePeriod)
        {
            var competition = CompetitionFactory.Create(Sport.Bowling, name, timePeriod);
            competition.CompetitionName = name;
            competition.TimePeriod = timePeriod;
            competition.Players = new List<Party>();
            competition.Matches = new List<Match>();
            _context.Add(competition);
            _context.SaveChanges();
            return competition.CompetitionId;
        }

        public List<Competition> ListCompetitions()
        {
            return _context.Competitions.ToList();
        }

        public List<Party> ListPlayers(Guid competitionId)
        {
            return _context.Competitions.FirstOrDefault(x => x.CompetitionId == competitionId).Players.ToList();
        }

        public void RegisterCompetitionPlayer(Guid competitionId, Guid partyId)
        {
            var player = _context.Players.FirstOrDefault(x => x.PartyId == partyId);
            var comp = _context.Competitions.FirstOrDefault(x => x.CompetitionId == competitionId);
            comp.Players.Add(player);
            _context.Update(comp);
            _context.SaveChanges();
        }

        public List<Match> GenerateMatches(Guid competitionId)
        {
            var compPlayers = ListPlayers(competitionId);
            if (compPlayers.Count % 2 != 0) return null;
            for (var i = 0; i < compPlayers.Count; i+=2)
            {
                //if (i % 2 != 0) continue;
                var playerOne = compPlayers[i];
                var playerTwo = compPlayers[i + 1];

                var match = MatchFactory.Create(playerOne.PartyId, playerTwo.PartyId);

                _context.Add(match);
                _context.SaveChanges();
            }
            return _context.Competitions.FirstOrDefault(x => x.CompetitionId == competitionId).Matches;
        }

        public Guid GetWinnerOfYear(int year)
        {
            var comps = _context.Competitions.Where(x => x.TimePeriod.EndDate.Year == year);
            var matches = comps.SelectMany(comp => comp.Matches);

            var winners = matches.Select(match => match.WinnerId).ToList();
            var players = matches.Select(match => match.PlayerOne).ToList();
            players.AddRange(matches.Select(match => match.PlayerTwo));
            players.OrderByDescending(x => x.PartyId);

            Guid winnerOfTheYear;
            int? mostWins = null;

            foreach (var player in players.Distinct())
            {
                var numberOfMatchesPlayed = players.Count(party => party.PartyId == player.PartyId);
                var numberOfMatchesWon = winners.Count(party => party == player.PartyId);

                if (numberOfMatchesWon == 0) continue;

                var wins = numberOfMatchesPlayed % numberOfMatchesWon;
                if (mostWins == null)
                {
                    mostWins = wins;
                    winnerOfTheYear = player.PartyId;
                }
                else
                {
                    if (!(wins > mostWins)) continue;
                    mostWins = wins;
                    winnerOfTheYear = player.PartyId;
                }
            }

            //winnerOfTheYear = winners.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).First();

            return winnerOfTheYear;
        }

        public Guid CreateVenue(string name, VenueType type)
        {
            _context.Add(new Venue {VenueId = Guid.NewGuid(), VenueType = type, VenueName = name});
            return Guid.NewGuid();
        }
    }
}
