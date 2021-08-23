using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoteFeatures.Commands
{
    class DeleteVoteByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteVoteByIdCommandHandler : IRequestHandler<DeleteVoteByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteVoteByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteVoteByIdCommand command, CancellationToken cancellationToken)
            {
                var vote = await _context.Votes.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (vote == null) return default;
                _context.Votes.Remove(vote);
                await _context.SaveChanges();
                return vote.Id;
            }
        }

    }
}
