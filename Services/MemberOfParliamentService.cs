using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    internal class MemberOfParliamentService : IMemberOfParliamentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public MemberOfParliamentService(IRepositoryManager repositoryManager)
        {
            repositoryManager = _repositoryManager;
        }
    }
}
