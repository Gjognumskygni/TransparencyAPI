using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MemberOfParliamentFeatures.Queries
{
    public class GetAllMemberOfParliamentsQuery : IRequest<IEnumerable<MemberOfParliament>>
    {
        public class GetAllMemberOfParliamentsQueryHandler : IRequestHandler<GetAllMemberOfParliamentsQuery, IEnumerable<MemberOfParliament>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllMemberOfParliamentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<MemberOfParliament>> Handle(GetAllMemberOfParliamentsQuery request, CancellationToken cancellationToken)
            {
                var memberOfParliamentList = await _context.MemberOfParliaments.ToListAsync();
                if (memberOfParliamentList == null)
                {
                    return null;
                }
                return memberOfParliamentList.AsReadOnly();
            }
        }
    }
}
