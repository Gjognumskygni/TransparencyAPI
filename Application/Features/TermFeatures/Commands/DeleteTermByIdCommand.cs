using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TermFeatures.Commands
{
    class DeleteVoteByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTermByIdCommandHandler : IRequestHandler<DeleteVoteByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteTermByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteVoteByIdCommand command, CancellationToken cancellationToken)
            {
                var term = await _context.Terms.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (term == null) return default;
                _context.Terms.Remove(term);
                await _context.SaveChanges();
                return term.Id;
            }
        }

    }
}
