using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoteFeatures.Queries
{
    class GetAllVotesQuery : IRequest<IEnumerable<Vote>>
    {
        public class GetAllVotesQueryHandler : IRequestHandler<GetAllVotesQuery, IEnumerable<Vote>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllVotesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Vote>> Handle(GetAllVotesQuery request, CancellationToken cancellationToken)
            {
                var voteList = await _context.Votes.ToListAsync();
                if (voteList == null)
                {
                    return null;
                }
                return voteList.AsReadOnly();
            }
        }
    }
}
