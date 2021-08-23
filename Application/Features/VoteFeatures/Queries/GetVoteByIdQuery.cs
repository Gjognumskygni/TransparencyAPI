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

namespace Application.Features.VoteFeatures.Queries
{
    public class GetVoteByIdQuery : IRequest<Vote>
    {
        public int Id { get; set; }
        public class GetVoteByIdQueryHandler : IRequestHandler<GetVoteByIdQuery, Vote>
        {
            private readonly IApplicationDbContext _context;
            public GetVoteByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Vote> Handle(GetVoteByIdQuery query, CancellationToken cancellationToken)
            {
                var vote = _context.Votes.Where(p => p.Id == query.Id).FirstOrDefault();
                if (vote == default) return null;
                return vote;
            }
        }
    }
}
