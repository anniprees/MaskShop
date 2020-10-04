using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Parties
{
    public sealed class PartyContactMechanismPurposeData : PeriodData
    {
        public string PartyContactMechanismId { get; set; }

        public string ContactMechanismPurposeTypeId { get; set; }
    }
}
