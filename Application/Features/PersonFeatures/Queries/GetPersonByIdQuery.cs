using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PersonFeatures.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
        public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
        {
            private readonly IApplicationDbContext _context;
            public GetPersonByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Person> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken)
            {
                var person = _context.Persons.Where(p => p.Id == query.Id).FirstOrDefault();
                if (person == default) return null;
                return person;
            }
        }
    }
}
