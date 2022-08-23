using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        int Commit();
        void Dispose();
        Task<IEnumerable<T>> GetAllASync();
        Task InsertAsync(T entity);
        void Update(T entity);
    }
}
