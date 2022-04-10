using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class PartyRepository : IPartyRepository
    {
        private readonly ApplicationDbContext _context;

        public PartyRepository(ApplicationDbContext context) => _context = context;
    }
}
