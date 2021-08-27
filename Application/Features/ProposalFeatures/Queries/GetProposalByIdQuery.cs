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

namespace Application.Features.ProposalFeatures.Queries
{
    public class GetProposalByIdQuery : IRequest<Proposal>
    {
        public int Id { get; set; }
        public class GetProposalByIdQueryHandler : IRequestHandler<GetProposalByIdQuery, Proposal>
        {
            private readonly IApplicationDbContext _context;
            public GetProposalByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Proposal> Handle(GetProposalByIdQuery query, CancellationToken cancellationToken)
            {
                var proposal = await _context.Proposals.Where(p => p.Id == query.Id).FirstOrDefaultAsync();
                if (proposal == default) return null;
                return proposal;
            }
        }
    }
}
