using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly Lazy<IMemberOfParliamentRepository> _lazyMemberOfParliamentRepository;
        private readonly Lazy<IPartyRepository> _lazyPartyRepository;
        private readonly Lazy<IProposalRepository> _lazyProposalRepository;
        private readonly Lazy<ITermRepository> _lazyTermRepository;

        public RepositoryManager(ApplicationDbContext applicationDbContext)
        {
            _lazyMemberOfParliamentRepository = new Lazy<IMemberOfParliamentRepository>(() => new MemberOfParliamentRepository(applicationDbContext));
            _lazyPartyRepository = new Lazy<IPartyRepository>(() => new PartyRepository(applicationDbContext));
            _lazyProposalRepository = new Lazy<IProposalRepository>(() => new ProposalRepository(applicationDbContext));
            _lazyTermRepository = new Lazy<ITermRepository>(() => new TermRepository(applicationDbContext));
        }
        public IMemberOfParliamentRepository MemberOfParliamentRepository => _lazyMemberOfParliamentRepository.Value;

        public IPartyRepository PartyRepository => _lazyPartyRepository.Value;

        public IProposalRepository ProposalRepository => _lazyProposalRepository.Value;

        public ITermRepository TermRepository => _lazyTermRepository.Value;
    }
}
