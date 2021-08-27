
using Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartyFeatures.Commands
{
    public class UpdatePartyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Letter { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public class UpdatePartyCommandHandler : IRequestHandler<UpdatePartyCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdatePartyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdatePartyCommand command, CancellationToken cancellationToken)
            {
                var party = _context.Parties.Where(a => a.Id == command.Id).FirstOrDefault();
                if (party == null)
                {
                    return default;
                }
                else
                {
                    party.Letter = command.Letter;
                    party.Name = command.Name;
                    party.StartDate = command.StartDate;
                    party.EndDate = command.EndDate;
                    await _context.SaveChanges();
                    return party.Id;
                }
            }
        }
    }
}
