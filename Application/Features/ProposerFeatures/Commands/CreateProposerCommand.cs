using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposerFeatures.Commands
{
    public class CreateProposerCommand : IRequest<int>
    {
        public MemberOfParliament MemberOfParliament { get; set; }
        public class CreateProposerCommandHandler : IRequestHandler<CreateProposerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProposerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProposerCommand command, CancellationToken cancellationToken)
            {
                var proposer = new Proposer();
                proposer.MemberOfParliament = command.MemberOfParliament;
                _context.Proposers.Add(proposer);
                await _context.SaveChanges();
                return proposer.Id;
            }
        }
    }
}
