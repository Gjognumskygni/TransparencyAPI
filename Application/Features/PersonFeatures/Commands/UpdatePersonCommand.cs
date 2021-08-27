
using Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PersonFeatures.Commands
{
    public class UpdatePersonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdatePersonCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
            {
                var person = _context.Persons.Where(a => a.Id == command.Id).FirstOrDefault();
                if (person == null)
                {
                    return default;
                }
                else
                {
                    person.Name = command.Name;
                    await _context.SaveChanges();
                    return person.Id;
                }
            }
        }
    }
}
