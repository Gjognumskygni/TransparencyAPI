using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MemberOfParliament : BaseEntity
    {
        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }

        public MemberOfParliamentRole MemberOfParliamentRole { get; init; }

        public Person Person { get; init; }

        public Party Party { get; init; }

        public Term Term { get; init; }
    }
}
