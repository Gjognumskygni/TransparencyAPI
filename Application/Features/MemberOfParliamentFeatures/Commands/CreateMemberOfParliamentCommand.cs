using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MemberOfParliamentFeatures.Commands
{
    class CreateMemberOfParliamentCommand : IRequest<int>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MemberOfParliamentRole MemberOfParliamentRole { get; set; }

        public Person Person { get; set; }

        public Party Party { get; set; }

        public Term Term { get; set; }
        public class CreateMemberOfParliamentCommandHandler : IRequestHandler<CreateMemberOfParliamentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateMemberOfParliamentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateMemberOfParliamentCommand command, CancellationToken cancellationToken)
            {
                var memberOfParliament = new MemberOfParliament();
                memberOfParliament.StartDate = command.StartDate;
                memberOfParliament.EndDate = command.EndDate;
                memberOfParliament.MemberOfParliamentRole = command.MemberOfParliamentRole;
                memberOfParliament.Person = command.Person;
                memberOfParliament.Party = command.Party;
                memberOfParliament.Term = command.Term;
                _context.MemberOfParliaments.Add(memberOfParliament);
                await _context.SaveChanges();
                return memberOfParliament.Id;
            }
        }
    }
}
