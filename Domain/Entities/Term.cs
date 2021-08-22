using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Term : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
