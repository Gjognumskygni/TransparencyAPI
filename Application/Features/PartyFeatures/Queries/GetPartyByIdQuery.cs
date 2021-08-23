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

namespace Application.Features.PartyFeatures.Queries
{
    public class GetPartyByIdQuery : IRequest<Party>
    {
        public int Id { get; set; }
        public class GetPartyByIdQueryHandler : IRequestHandler<GetPartyByIdQuery, Party>
        {
            private readonly IApplicationDbContext _context;
            public GetPartyByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Party> Handle(GetPartyByIdQuery query, CancellationToken cancellationToken)
            {
                var party = _context.Parties.Where(p => p.Id == query.Id).FirstOrDefault();
                if (party == default) return null;
                return party;
            }
        }
    }
}
