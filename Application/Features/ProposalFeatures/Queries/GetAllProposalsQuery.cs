using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProposalFeatures.Queries
{
    public class GetAllProposalsQuery : IRequest<IEnumerable<Proposal>>
    {
        public class GetAllProposalsQueryHandler : IRequestHandler<GetAllProposalsQuery, IEnumerable<Proposal>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProposalsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Proposal>> Handle(GetAllProposalsQuery request, CancellationToken cancellationToken)
            {
                var proposalList = await _context.Proposals.ToListAsync();
                if (proposalList == null)
                {
                    return null;
                }
                return proposalList.AsReadOnly();
            }
        }
    }
}
