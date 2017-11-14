using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AccountabilityInterfacesLib;
using AccountabilityLib;
using BowlingSystemDbLib;
using BowlingSystemInterfacesLib;
using CompetitionLib;

namespace BowlingSystemLib
{
    //FACADE
    public class BowlingSystem
    {

        private readonly IBowlingRepository _competitionRepository;

        public BowlingSystem(IBowlingRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        public Guid CreateCompetition(string name, TimePeriod timePeriod) => _competitionRepository.Create(name, timePeriod);

        public List<Competition> ListCompetitions() => _competitionRepository.ListCompetitions();

        public List<Party> ListPlayers(Guid competitionId) => _competitionRepository.ListPlayers(competitionId);

        public bool RegisterCompetitionPlayer(Guid competitionId, Guid partyId)
        {
            if (ListPlayers(competitionId).Count >= 10) return false;
            _competitionRepository.RegisterCompetitionPlayer(competitionId, partyId);
            return true;
        }

        public List<Match> GenerateMatches(Guid competitionId) => _competitionRepository.GenerateMatches(competitionId);

        public Guid GetWinnerOfYear(int year) => _competitionRepository.GetWinnerOfYear(year);

        public Guid CreateVenue(string name, VenueType type) => _competitionRepository.CreateVenue(name, VenueType.Lane);
    }
}
