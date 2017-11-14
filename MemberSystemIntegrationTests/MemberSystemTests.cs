using BowlingSystemDbLib;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MemberSystemLib;
using System.Linq;
using AccountabilityLib;

namespace MemberSystemIntegrationTests
{
    public class MemberSystemTests
    {
        private BowlingSystemContext _context;

        public MemberSystemTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BowlingSystemContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new BowlingSystemContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void CanCreateMember()
        {
            //Arrange
            var expectedResult = "Isabella";
            var sut = new MemberSystem(new SqlPartyRepository(_context));
            //Act
            var partyGuid = sut.Create(expectedResult, "870310");
            var party = _context.Players.FirstOrDefault(x => x.PartyId == partyGuid);
            //Assert
            Assert.Equal(expectedResult, party.Name);
        }
        [Fact]
        public void CanSearchMemberByGuid()
        {
            //Arrange
            var sut = new MemberSystem(new SqlPartyRepository(_context));
            //Act
            var player = new Party
            {
                PartyId = Guid.NewGuid(),
                Name = "Isabella",
                LegalId = "870310"
            };
            _context.Players.Add(player);
            _context.SaveChanges();
            var searchResult = sut.GetById(player.PartyId);
            //Assert
            Assert.Equal(player.Name, searchResult.Name);
        }
    }
}