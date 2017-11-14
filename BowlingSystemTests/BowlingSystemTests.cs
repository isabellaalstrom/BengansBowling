using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;
using CompetitionLib;
using AccountabilityLib;

namespace BowlingSystemUnitTests
{
    public class BowlingSystemTests
    {
        [Fact]
        public void CanGetMatchWinner()
        {
            //Arrange
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
            var rounds = new List<Round> {r1, r2, r3};

            var match = new CompetitionLib.Match
            {
                MatchId = Guid.NewGuid(),
                Rounds = rounds,
                PlayerOneId = p1.PartyId,
                PlayerOne = p1,
                PlayerTwoId = p2.PartyId,
                PlayerTwo = p2
            };
            
            //Act
            var winnerId = match.WinnerId;
            
            //Assert
            Assert.Equal(p2.PartyId, winnerId);
        }

        [Fact]
        public void CanCreateCompetition()
        {
            //Arrange
            var compName = "Bowling All Stars";
            //Act
            var comp = CompetitionFactory.Create(Sport.Bowling, compName, new TimePeriod
            {
                StartDate = new DateTime(2017, 10, 23),
                EndDate = new DateTime(2017, 11, 23)
            });
            //Assert
            Assert.Equal(compName, comp.CompetitionName);
        }
        [Fact]
        public void CanCreateMatch()
        {
            //Arrange
            var p1Id = Guid.NewGuid();
            var p2Id = Guid.NewGuid();

            //Act
            var match = MatchFactory.Create(p1Id, p2Id);
            //Assert
            Assert.Equal(p1Id, match.PlayerOneId);
        }
    }
}