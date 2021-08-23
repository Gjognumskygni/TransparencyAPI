using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PersonFeatures.Commands
{
    class DeletePersonByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePersonByIdCommandHandler : IRequestHandler<DeletePersonByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeletePersonByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePersonByIdCommand command, CancellationToken cancellationToken)
            {
                var person = await _context.Persons.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (person == null) return default;
                _context.Persons.Remove(person);
                await _context.SaveChanges();
                return person.Id;
            }
        }

    }
}
