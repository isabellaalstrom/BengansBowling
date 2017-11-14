using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AccountabilityInterfacesLib;
using AccountabilityLib;

namespace BowlingSystemDbLib
{
    public class SqlPartyRepository : IPartyRepository
    {
        private readonly BowlingSystemContext _context;

        public SqlPartyRepository(BowlingSystemContext context)
        {
            _context = context;
        }
        public Guid Create(string name, string legalId)
        {
            var party = new Party { PartyId = Guid.NewGuid(), Name = name, LegalId = legalId };
            _context.Add(party);
            _context.SaveChanges();
            return party.PartyId;
        }

        public Party GetById(Guid partyId) => _context.Players.FirstOrDefault(x => x.PartyId == partyId);


        public IEnumerable<Party> SearchByName(string name) => _context.Players.Where(x => x.Name.Contains(name)).ToList();

        public void Update(Guid partyId, string name, string legalId)
        {
            var party = _context.Players.FirstOrDefault(x => x.PartyId == partyId);
            party.Name = name;
            party.LegalId = legalId;
            _context.Update(party);
            _context.SaveChanges();
        }

        public void Delete(Guid partyId)
        {
            var party = _context.Players.FirstOrDefault(x=>x.PartyId==partyId);
            _context.Remove(party);
            _context.SaveChanges();
        }
    }
}
