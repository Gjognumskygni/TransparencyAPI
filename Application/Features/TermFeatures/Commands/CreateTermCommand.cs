using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TermFeatures.Commands
{
    class CreateVoteCommand : IRequest<int>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public class CreateTermCommandHandler : IRequestHandler<CreateVoteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateTermCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateVoteCommand command, CancellationToken cancellationToken)
            {
                var term = new Term();
                term.StartDate = command.StartDate;
                term.EndDate = command.EndDate;
                _context.Terms.Add(term);
                await _context.SaveChanges();
                return term.Id;
            }
        }
    }
}
