using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MemberOfParliamentRepository : BaseRepository<MemberOfParliament>, IMemberOfParliamentRepository
    {
        public MemberOfParliamentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<MemberOfParliament> GetByIdAsync(Guid id) => await base._context.MemberOfParliaments.SingleOrDefaultAsync(e => e.Id == id);
    }
}
