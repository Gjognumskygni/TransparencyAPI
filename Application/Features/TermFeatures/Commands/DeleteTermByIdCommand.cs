using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TermFeatures.Commands
{
    public class DeleteTermByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTermByIdCommandHandler : IRequestHandler<DeleteTermByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteTermByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTermByIdCommand command, CancellationToken cancellationToken)
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
