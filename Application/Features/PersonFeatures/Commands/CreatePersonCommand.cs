using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PersonFeatures.Commands
{
    class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreatePersonCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
            {
                var person = new Person();
                person.Name = command.Name;
                _context.Persons.Add(person);
                await _context.SaveChanges();
                return person.Id;
            }
        }
    }
}
