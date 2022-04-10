using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class MemberOfParliamentRepository : IMemberOfParliamentRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberOfParliamentRepository(ApplicationDbContext context) => _context = context;
    }
}
