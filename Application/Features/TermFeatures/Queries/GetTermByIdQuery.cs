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

namespace Application.Features.TermFeatures.Queries
{
    public class GetTermByIdQuery : IRequest<Term>
    {
        public int Id { get; set; }
        public class GetTermByIdQueryHandler : IRequestHandler<GetTermByIdQuery, Term>
        {
            private readonly IApplicationDbContext _context;
            public GetTermByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Term> Handle(GetTermByIdQuery query, CancellationToken cancellationToken)
            {
                var term = _context.Terms.Where(p => p.Id == query.Id).FirstOrDefault();
                if (term == default) return null;
                return term;
            }
        }
    }
}
