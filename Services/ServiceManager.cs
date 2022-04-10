using Domain.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMemberOfParliamentService> _lazyMemberOfParliamentService;
        private readonly Lazy<IPartyService> _lazyPartyService;
        private readonly Lazy<IProposalService> _lazyProposalService;
        private readonly Lazy<ITermService> _lazyTermService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyMemberOfParliamentService = new Lazy<IMemberOfParliamentService>(() => new MemberOfParliamentService(repositoryManager));
            _lazyPartyService = new Lazy<IPartyService>(() => new PartyService(repositoryManager));
            _lazyProposalService = new Lazy<IProposalService>(() => new ProposalService(repositoryManager));
            _lazyTermService = new Lazy<ITermService>(() => new TermService(repositoryManager));
        }
        public IMemberOfParliamentService MemberOfParliamentService => _lazyMemberOfParliamentService.Value;

        public IPartyService PartyService => _lazyPartyService.Value;

        public IProposalService ProposalService => _lazyProposalService.Value;

        public ITermService TermService => _lazyTermService.Value;
    }
}
