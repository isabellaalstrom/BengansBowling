using BowlingSystemDbLib;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using BowlingSystemLib;
using CompetitionLib;
using AccountabilityLib;

namespace BowlingSystemIntegrationTestsLib
{
    public class BowlingSystemTests
    {
        private BowlingSystemContext _context;

        public BowlingSystemTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BowlingSystemContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new BowlingSystemContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            InitiateDatabase();
        }

        [Fact]
        public void CanGenerateMatchesForCompetition()
        {
            var sut = new BowlingSystem(new SqlBowlingRepository(_context));
            //Arrange
            var comp = _context.Competitions.FirstOrDefault();
            var playerCount = comp.Players.Count();
            //Act
            var list = sut.GenerateMatches(comp.CompetitionId);

            //Assert
            Assert.Equal(playerCount / 2, list.Count);
        }

        [Fact]
        public void CanGetWinnerOfYear()
        {
            var sut = new BowlingSystem(new SqlBowlingRepository(_context));
            
            //Arrange
            var expectedWinner = _context.Players.FirstOrDefault(x => x.Name == "Stefan");

            //Act
            var winnerOfYear = sut.GetWinnerOfYear(2017);

            //Assert
            Assert.Equal(expectedWinner.PartyId, winnerOfYear);
        }

        private void InitiateDatabase()
        {
            var p1 = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Isa",
                LegalId = "870310"
            };
            var p2 = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Stefan",
                LegalId = "840221"
            };
            var p3 = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Player3",
                LegalId = "840221"
            }; var p4 = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Player4",
                LegalId = "840221"
            }; var p5 = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Player5",
                LegalId = "840221"
            }; var p6 = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Player6",
                LegalId = "840221"
            };
            var players = new List<Party> { p2, p1, p3, p4, p5, p6 };
            _context.Players.Add(p1);
            _context.Players.Add(p2);
            _context.Players.Add(p3);
            _context.Players.Add(p4);
            _context.Players.Add(p5);
            _context.Players.Add(p6);


            var s1 = new Series
            {
                SeriesId = Guid.NewGuid(),
                Score = 1
            };
            var s2 = new Series
            {
                SeriesId = Guid.NewGuid(),
                Score = 1
            };
            var s3 = new Series
            {
                SeriesId = Guid.NewGuid(),
                Score = 1
            };

            var s4 = new Series
            {
                SeriesId = Guid.NewGuid(),
                Score = 11
            };
            var s5 = new Series
            {
                SeriesId = Guid.NewGuid(),
                Score = 11
            };
            var s6 = new Series
            {
                SeriesId = Guid.NewGuid(),
                Score = 11
            };

            _context.Series.Add(s1);
            _context.Series.Add(s2);
            _context.Series.Add(s3);
            _context.Series.Add(s4);
            _context.Series.Add(s5);
            _context.Series.Add(s6);

            var r1 = new Round
            {
                RoundId = Guid.NewGuid(),
                PlayerOneSeries = s1,
                PlayerTwoSeries = s4
            };
            var r2 = new Round
            {
                RoundId = Guid.NewGuid(),
                PlayerOneSeries = s2,
                PlayerTwoSeries = s5
            };
            var r3 = new Round
            {
                RoundId = Guid.NewGuid(),
                PlayerOneSeries = s3,
                PlayerTwoSeries = s6
            };

            var rounds = new List<Round> { r1, r2, r3 };
            _context.Rounds.AddRange(rounds);

            var match1 = new CompetitionLib.Match
            {
                MatchId = Guid.NewGuid(),
                Rounds = rounds,
                PlayerOneId = p1.PartyId,
                PlayerOne = p1,
                PlayerTwoId = p2.PartyId,
                PlayerTwo = p2
            };

            var match2 = new CompetitionLib.Match
            {
                MatchId = Guid.NewGuid(),
                Rounds = rounds,
                PlayerOneId = p1.PartyId,
                PlayerOne = p1,
                PlayerTwoId = p2.PartyId,
                PlayerTwo = p2
            };

            var match3 = new CompetitionLib.Match
            {
                MatchId = Guid.NewGuid(),
                Rounds = rounds,
                PlayerOneId = p2.PartyId,
                PlayerOne = p2,
                PlayerTwoId = p1.PartyId,
                PlayerTwo = p1
            };
            var matches = new List<CompetitionLib.Match> { match1, match2, match3 };
            _context.Matches.AddRange(matches);
            var winner1 = match1.WinnerId;
            var winner2 = match2.WinnerId;
            var winner3 = match3.WinnerId;

            var comp = new Competition
            {
                Sport = Sport.Bowling,
                CompetitionId = Guid.NewGuid(),
                CompetitionName = "September competition",
                TimePeriod = new TimePeriod
                {
                    TimePeriodId = Guid.NewGuid(),
                    StartDate = new DateTime(2017, 09, 01),
                    EndDate = new DateTime(2017, 10, 01)
                },
                Players = players,
                Matches = matches
            };

            _context.Competitions.Add(comp);
            _context.SaveChanges();
        }
    }
}
