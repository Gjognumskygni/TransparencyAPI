
using Application.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TermFeatures.Commands
{
    public class UpdateTermCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public class UpdateTermCommandHandler : IRequestHandler<UpdateTermCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateTermCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTermCommand command, CancellationToken cancellationToken)
            {
                var term = _context.Terms.Where(a => a.Id == command.Id).FirstOrDefault();
                if (term == null)
                {
                    return default;
                }
                else
                {
                    term.StartDate = command.StartDate;
                    term.EndDate = command.EndDate;
                    await _context.SaveChanges();
                    return term.Id;
                }
            }
        }
    }
}
