using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Proposer : BaseEntity
    {
        public MemberOfParliament MemberOfParliament { get; init; }
    }
}
