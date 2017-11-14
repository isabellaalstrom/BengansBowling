using System;
using AccountabilityLib;
using CompetitionLib;
using Microsoft.EntityFrameworkCore;

namespace BowlingSystemDbLib
{
    public class BowlingSystemContext : DbContext
    {
        public BowlingSystemContext(DbContextOptions<BowlingSystemContext> options) : base(options)
        {
        }
        public DbSet<Venue> Assets { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<TimePeriod> TimePeriods { get; set; }
        public DbSet<Party> Players { get; set; }
    }
}