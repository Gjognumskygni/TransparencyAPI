using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IMemberOfParliamentService MemberOfParliamentService { get; }
        IPartyService PartyService { get; }
        IProposalService ProposalService { get; }
        ITermService TermService { get; }
    }
}
