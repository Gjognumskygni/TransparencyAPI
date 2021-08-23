using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TermFeatures.Queries
{
    class GetAllVotesQuery : IRequest<IEnumerable<Term>>
    {
        public class GetAllTermsQueryHandler : IRequestHandler<GetAllVotesQuery, IEnumerable<Term>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTermsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Term>> Handle(GetAllVotesQuery request, CancellationToken cancellationToken)
            {
                var termList = await _context.Terms.ToListAsync();
                if (termList == null)
                {
                    return null;
                }
                return termList.AsReadOnly();
            }
        }
    }
}
