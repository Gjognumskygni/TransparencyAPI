using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TermRepository : BaseRepository<Term>, ITermRepository
    {
        public TermRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
