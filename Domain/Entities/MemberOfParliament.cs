using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MemberOfParliament : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MemberOfParliamentRole MemberOfParliamentRole { get; set; }

        public Person Person { get; set; }

        public Party Party { get; set; }

        public Term Term { get; set; }
    }
}
