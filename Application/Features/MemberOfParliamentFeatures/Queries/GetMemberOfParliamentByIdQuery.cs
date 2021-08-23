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

namespace Application.Features.MemberOfParliamentFeatures.Queries
{
    public class GetMemberOfParliamentByIdQuery : IRequest<MemberOfParliament>
    {
        public int Id { get; set; }
        public class GetMemberOfParliamentByIdQueryHandler : IRequestHandler<GetMemberOfParliamentByIdQuery, MemberOfParliament>
        {
            private readonly IApplicationDbContext _context;
            public GetMemberOfParliamentByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<MemberOfParliament> Handle(GetMemberOfParliamentByIdQuery query, CancellationToken cancellationToken)
            {
                var memberOfParliament = _context.MemberOfParliaments.Where(m => m.Id == query.Id).FirstOrDefault();
                if (memberOfParliament == default) return null;
                return memberOfParliament;
            }
        }
    }
}
