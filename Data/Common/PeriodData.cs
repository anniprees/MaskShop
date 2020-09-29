using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Common
{
    public abstract class PeriodData
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
