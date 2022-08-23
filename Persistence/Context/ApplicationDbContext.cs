using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<MemberOfParliament> MemberOfParliaments { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Proposer> Proposers { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Party>()
                .HasKey(p => p.Letter);
        }
    }
}
