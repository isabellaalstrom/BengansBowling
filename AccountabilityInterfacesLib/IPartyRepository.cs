using System;
using System.Collections.Generic;
using AccountabilityLib;

namespace AccountabilityInterfacesLib
{
    public interface IPartyRepository
    {
        Guid Create(string name, string legalId);
        Party GetById(Guid partyId);
        IEnumerable<Party> SearchByName(string name);
        void Update(Guid partyId, string name, string legalId);
        void Delete(Guid partyId);
    }
}
