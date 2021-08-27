using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MemberOfParliamentFeatures.Commands
{
    public class DeleteMemberOfParliamentByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteMemberOfParliamentByIdCommandHandler : IRequestHandler<DeleteMemberOfParliamentByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteMemberOfParliamentByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteMemberOfParliamentByIdCommand command, CancellationToken cancellationToken)
            {
                var memberOfParliament = await _context.MemberOfParliaments.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (memberOfParliament == null) return default;
                _context.MemberOfParliaments.Remove(memberOfParliament);
                await _context.SaveChanges();
                return memberOfParliament.Id;
            }
        }

    }
}
