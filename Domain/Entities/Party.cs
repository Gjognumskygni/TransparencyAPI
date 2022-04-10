using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Party
    {
        public string Letter { get; init; }

        public char Name { get; init; }

        public DateTime StartDate { get; init; }

        public DateTime EndDate { get; init; }
        public IEnumerable<MemberOfParliament> MemberOfParliament { get; init; }
    }
}
