using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public class MemberOfParliamentService : IMemberOfParliamentService
    {
        private readonly IMemberOfParliamentRepository _memberOfParliamentRepository;

        public MemberOfParliamentService(IMemberOfParliamentRepository memberOfParliamentRepository)
        {
            _memberOfParliamentRepository = memberOfParliamentRepository;
        }

        public async Task<IEnumerable<MemberOfParliament>> GetAllAsync() => await _memberOfParliamentRepository.GetAllASync();

        public async Task<MemberOfParliament> GetByIdAsync(Guid id) => await _memberOfParliamentRepository.GetByIdAsync(id);
    }
}
