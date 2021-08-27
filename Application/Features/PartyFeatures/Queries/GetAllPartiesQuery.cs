using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartyFeatures.Queries
{
    public class GetAllPartiesQuery : IRequest<IEnumerable<Party>>
    {
        public class GetAllPartysQueryHandler : IRequestHandler<GetAllPartiesQuery, IEnumerable<Party>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPartysQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Party>> Handle(GetAllPartiesQuery request, CancellationToken cancellationToken)
            {
                var partyList = await _context.Parties.ToListAsync();
                if (partyList == null)
                {
                    return null;
                }
                return partyList.AsReadOnly();
            }
        }
    }
}
