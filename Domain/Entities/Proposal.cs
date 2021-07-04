﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Proposal : BaseEntity
    {
        public ICollection<Proposer> Proposers { get; }
        public ICollection<Vote> Votes { get; }
    }
}
