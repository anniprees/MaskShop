﻿using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Parties
{
    public sealed class PartyContactMechanismData : PeriodData
    {
        public string PartyId { get; set; }

        public string ContactMechanismId { get; set; }
    }
}
