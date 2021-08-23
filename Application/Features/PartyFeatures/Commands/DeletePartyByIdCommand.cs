using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartyFeatures.Commands
{
    class DeletePartyByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePartyByIdCommandHandler : IRequestHandler<DeletePartyByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeletePartyByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePartyByIdCommand command, CancellationToken cancellationToken)
            {
                var party = await _context.Parties.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (party == null) return default;
                _context.Parties.Remove(party);
                await _context.SaveChanges();
                return party.Id;
            }
        }

    }
}
