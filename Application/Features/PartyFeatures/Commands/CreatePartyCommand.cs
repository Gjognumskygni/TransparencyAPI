using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartyFeatures.Commands
{
    public class CreatePartyCommand : IRequest<int>
    {
        public string Letter { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public class CreatePartyCommandHandler : IRequestHandler<CreatePartyCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreatePartyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreatePartyCommand command, CancellationToken cancellationToken)
            {
                var party = new Party();
                party.Letter = command.Letter;
                party.Name = command.Name;
                party.StartDate = command.StartDate;
                party.EndDate = command.EndDate;
                _context.Parties.Add(party);
                await _context.SaveChanges();
                return party.Id;
            }
        }
    }
}
