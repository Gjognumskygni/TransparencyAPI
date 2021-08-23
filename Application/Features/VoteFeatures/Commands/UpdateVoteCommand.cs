
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoteFeatures.Commands
{
    class UpdateVoteCommand : IRequest<int>
    {
        public int Id { get; set; }

        public MemberOfParliament MemberOfParliament { get; set; }

        public VoteType VoteType { get; set; }

        public DateTime EndDate { get; set; }
        public class UpdateVoteCommandHandler : IRequestHandler<UpdateVoteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateVoteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateVoteCommand command, CancellationToken cancellationToken)
            {
                var vote = _context.Votes.Where(a => a.Id == command.Id).FirstOrDefault();
                if (vote == null)
                {
                    return default;
                }
                else
                {
                    vote.MemberOfParliament = command.MemberOfParliament;
                    vote.VoteType = command.VoteType;
                    await _context.SaveChanges();
                    return vote.Id;
                }
            }
        }
    }
}
