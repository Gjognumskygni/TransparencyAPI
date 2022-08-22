using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IMemberOfParliamentService
    {
        Task<IEnumerable<MemberOfParliament>> GetAllAsync();
        Task<MemberOfParliament> GetByIdAsync(Guid id);
    }
}
