using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vote : BaseEntity
    {

        public MemberOfParliament MemberOfParliament { get; init; }

        public VoteType VoteType { get; init; }
    }
}
