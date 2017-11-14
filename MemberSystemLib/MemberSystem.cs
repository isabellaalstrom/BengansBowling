using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityInterfacesLib;
using AccountabilityLib;

namespace MemberSystemLib
{
    public class MemberSystem
    {
        private readonly IPartyRepository _partyRepository;

        public MemberSystem(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public Guid Create(string name, string legalId) => _partyRepository.Create(name, legalId);

        public Party GetById(Guid partyId) => _partyRepository.GetById(partyId);

        public IEnumerable<Party> SearchByName(string name) => _partyRepository.SearchByName(name);

        public void Update(Guid partyId, string name, string legalId) => _partyRepository.Update(partyId, name, legalId);

        public void Delete(Guid partyId) => _partyRepository.Delete(partyId);
    }
}