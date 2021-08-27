
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposerFeatures.Commands
{
    public class UpdateProposerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public MemberOfParliament MemberOfParliament { get; set; }
        public class UpdateProposerCommandHandler : IRequestHandler<UpdateProposerCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProposerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProposerCommand command, CancellationToken cancellationToken)
            {
                var proposer = _context.Proposers.Where(a => a.Id == command.Id).FirstOrDefault();
                if (proposer == null)
                {
                    return default;
                }
                else
                {
                    proposer.MemberOfParliament = command.MemberOfParliament;
                    await _context.SaveChanges();
                    return proposer.Id;
                }
            }
        }
    }
}
