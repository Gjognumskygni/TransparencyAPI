using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IMemberOfParliamentRepository MemberOfParliamentRepository { get; }
        IPartyRepository PartyRepository { get; }
        IProposalRepository ProposalRepository { get; }
        ITermRepository TermRepository { get; }
    }
}
