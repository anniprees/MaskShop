using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Objects
{
    public sealed class PartyObjectData : PeriodData
    {
        public string PartyId { get; set; }

        public string ObjectId { get; set; }
    }
}
