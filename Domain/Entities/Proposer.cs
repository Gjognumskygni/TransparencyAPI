using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Proposer : BaseEntity
    {
        public int MemberOfParliamentId { get; set; }
        public MemberOfParliament MemberOfParliament { get; set; }
    }
}
