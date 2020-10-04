using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Parties
{
    public abstract class PartyAttributeData : UniqueEntityData
    {
        public string PartyId { get; set; }
    }
}
