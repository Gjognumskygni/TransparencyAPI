using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vote : BaseEntity
    {

        public MemberOfParliament MemberOfParliament { get; set; }

        public VoteType VoteType { get; set; }
    }
}
