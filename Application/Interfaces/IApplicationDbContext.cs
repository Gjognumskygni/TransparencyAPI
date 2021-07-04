using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<MemberOfParliament> MemberOfParliaments { get; set; }

        public DbSet<Party> Parties { get; set; }

        public DbSet<Term> Terms { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<Proposer> Proposers { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}
