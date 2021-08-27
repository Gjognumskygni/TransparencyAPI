using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposalFeatures.Commands
{
    public class DeleteProposalByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProposalByIdCommandHandler : IRequestHandler<DeleteProposalByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProposalByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProposalByIdCommand command, CancellationToken cancellationToken)
            {
                var proposal = await _context.Proposals.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (proposal == null) return default;
                _context.Proposals.Remove(proposal);
                await _context.SaveChanges();
                return proposal.Id;
            }
        }

    }
}
