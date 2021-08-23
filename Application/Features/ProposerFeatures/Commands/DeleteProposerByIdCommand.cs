using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposerFeatures.Commands
{
    class DeleteProposerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProposerByIdCommandHandler : IRequestHandler<DeleteProposerByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProposerByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProposerByIdCommand command, CancellationToken cancellationToken)
            {
                var proposer = await _context.Proposers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (proposer == null) return default;
                _context.Proposers.Remove(proposer);
                await _context.SaveChanges();
                return proposer.Id;
            }
        }

    }
}
