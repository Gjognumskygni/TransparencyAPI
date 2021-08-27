using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoteFeatures.Commands
{
    public class CreateVoteCommand : IRequest<int>
    {
        public MemberOfParliament MemberOfParliament { get; set; }

        public VoteType VoteType { get; set; }
        public class CreateVoteCommandHandler : IRequestHandler<CreateVoteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateVoteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateVoteCommand command, CancellationToken cancellationToken)
            {
                var vote = new Vote();
                vote.MemberOfParliament = command.MemberOfParliament;
                vote.VoteType = command.VoteType;
                _context.Votes.Add(vote);
                await _context.SaveChanges();
                return vote.Id;
            }
        }
    }
}
