using System;
using System.Collections.Generic;
using AccountabilityLib;
using CompetitionLib;

namespace BowlingSystemInterfacesLib
{
    public interface IBowlingRepository
    {
        Guid Create(string name, TimePeriod timePeriod);
        List<Competition> ListCompetitions();
        List<Party> ListPlayers(Guid competitionId);
        void RegisterCompetitionPlayer(Guid competitionId, Guid partyId);
        List<Match> GenerateMatches(Guid competitionId);
        Guid GetWinnerOfYear(int year);
        Guid CreateVenue(string name, VenueType type);
    }
}