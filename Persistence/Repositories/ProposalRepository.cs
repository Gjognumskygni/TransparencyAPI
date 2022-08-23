using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
    {
        public ProposalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
