using System;

namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberOfParliamentRepository MembersOfParliament { get; }
        IPartyRepository Parties { get; }
        IProposalRepository Proposals { get; }
        ITermRepository Terms { get; }
        int Commit();
    }
}
