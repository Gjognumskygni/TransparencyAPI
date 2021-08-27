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

namespace Application.Features.ProposerFeatures.Queries
{
    public class GetProposerByIdQuery : IRequest<Proposer>
    {
        public int Id { get; set; }
        public class GetProposerByIdQueryHandler : IRequestHandler<GetProposerByIdQuery, Proposer>
        {
            private readonly IApplicationDbContext _context;
            public GetProposerByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Proposer> Handle(GetProposerByIdQuery query, CancellationToken cancellationToken)
            {
                var proposer = _context.Proposers.Where(p => p.Id == query.Id).FirstOrDefault();
                if (proposer == default) return null;
                return proposer;
            }
        }
    }
}
