
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MemberOfParliamentFeatures.Commands
{
    class UpdateMemberOfParliamentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MemberOfParliamentRole MemberOfParliamentRole { get; set; }

        public Person Person { get; set; }

        public Party Party { get; set; }

        public Term Term { get; set; }
        public class UpdateMemberOfParliamentCommandHandler : IRequestHandler<UpdateMemberOfParliamentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateMemberOfParliamentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateMemberOfParliamentCommand command, CancellationToken cancellationToken)
            {
                var memberOfParliament = _context.MemberOfParliaments.Where(a => a.Id == command.Id).FirstOrDefault();
                if (memberOfParliament == null)
                {
                    return default;
                }
                else
                {
                    memberOfParliament.StartDate = command.StartDate;
                    memberOfParliament.EndDate = command.EndDate;
                    memberOfParliament.MemberOfParliamentRole = command.MemberOfParliamentRole;
                    memberOfParliament.Person = command.Person;
                    memberOfParliament.Party = command.Party;
                    memberOfParliament.Term = command.Term;
                    await _context.SaveChanges();
                    return memberOfParliament.Id;
                }
            }
        }
    }
}
