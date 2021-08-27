using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PersonFeatures.Queries
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<Person>>
    {
        public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<Person>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPersonsQueryHandler(IApplicationDbContext context)
            {   
                _context = context;
            }
            public async Task<IEnumerable<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
            {
                var personList = await _context.Persons.ToListAsync();
                if (personList == null)
                {
                    return null;
                }
                return personList.AsReadOnly();
            }
        }
    }
}
