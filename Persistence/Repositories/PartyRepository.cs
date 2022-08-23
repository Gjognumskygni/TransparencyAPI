using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PartyRepository : BaseRepository<Party>, IPartyRepository
    {
        public PartyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
