using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public class MemberOfParliamentService : IMemberOfParliamentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberOfParliamentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MemberOfParliament>> GetAllAsync() => await _unitOfWork.MembersOfParliament.GetAllASync();

        public async Task<MemberOfParliament> GetByIdAsync(Guid id) => await _unitOfWork.MembersOfParliament.GetByIdAsync(id);
    }
}
