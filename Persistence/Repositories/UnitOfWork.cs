using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IMemberOfParliamentRepository MembersOfParliament { get; }

        public IPartyRepository Parties { get; }

        public IProposalRepository Proposals { get; }

        public ITermRepository Terms { get; }


        public UnitOfWork(ApplicationDbContext context, IMemberOfParliamentRepository membersOfParliament, IPartyRepository parties, IProposalRepository proposals, ITermRepository terms)
        {
            _context = context;
            MembersOfParliament = membersOfParliament;
            Parties = parties;
            Proposals = proposals;
            Terms = terms;
        }

        public int Commit() => _context.SaveChanges();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
                _context.Dispose();
        }
    }
}
