using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposalFeatures.Commands
{
    public class CreateProposalCommand : IRequest<int>
    {
        public ICollection<Proposer> Proposers { get; }
        public ICollection<Vote> Votes { get; }
        public class CreateProposalCommandHandler : IRequestHandler<CreateProposalCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProposalCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProposalCommand command, CancellationToken cancellationToken)
            {
                var proposal = new Proposal();
                proposal.Proposers = command.Proposers;
                proposal.Votes = command.Votes;
                _context.Proposals.Add(proposal);
                await _context.SaveChanges();
                return proposal.Id;
            }
        }
    }
}
