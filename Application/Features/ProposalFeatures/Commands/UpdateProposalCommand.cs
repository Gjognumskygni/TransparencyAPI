
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposalFeatures.Commands
{
    public class UpdateProposalCommand : IRequest<int>
    {
        public int Id { get; set; }
        public ICollection<Proposer> Proposers { get; }
        public ICollection<Vote> Votes { get; }
        public class UpdateProposalCommandHandler : IRequestHandler<UpdateProposalCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProposalCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProposalCommand command, CancellationToken cancellationToken)
            {
                var proposal = _context.Proposals.Where(a => a.Id == command.Id).FirstOrDefault();
                if (proposal == null)
                {
                    return default;
                }
                else
                {
                    proposal.Proposers = command.Proposers;
                    proposal.Votes = command.Votes;
                    await _context.SaveChanges();
                    return proposal.Id;
                }
            }
        }
    }
}
