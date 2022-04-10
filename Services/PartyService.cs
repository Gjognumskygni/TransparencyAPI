using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class PartyService : IPartyService
    {
        private IRepositoryManager _repositoryManager;

        public PartyService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
