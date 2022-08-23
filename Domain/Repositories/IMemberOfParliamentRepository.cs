using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMemberOfParliamentRepository : IBaseRepository<MemberOfParliament>
    {
        Task<MemberOfParliament> GetByIdAsync(Guid id);
    }
}
