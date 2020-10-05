using System;

namespace Data.Common
{
    public abstract class PeriodData
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
