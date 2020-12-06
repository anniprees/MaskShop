﻿using MaskShop.Data.Common;

namespace MaskShop.Data.Parties
{
    public sealed class PartyData : UniqueEntityData
    {
        public string PartyNameId { get; set; }
        public string PartyRoleId { get; set; }
        public string ContactMechanismId { get; set; }
        public PartyTypeData PartyType { get; set; }
    }
}
