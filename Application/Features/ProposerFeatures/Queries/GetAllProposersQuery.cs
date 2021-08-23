using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposerFeatures.Queries
{
    class GetAllProposersQuery : IRequest<IEnumerable<Proposer>>
    {
        public class GetAllProposersQueryHandler : IRequestHandler<GetAllProposersQuery, IEnumerable<Proposer>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProposersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Proposer>> Handle(GetAllProposersQuery request, CancellationToken cancellationToken)
            {
                var proposerList = await _context.Proposers.ToListAsync();
                if (proposerList == null)
                {
                    return null;
                }
                return proposerList.AsReadOnly();
            }
        }
    }
}
