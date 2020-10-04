using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Parties
{
    public sealed class PartyNameData : PartyAttributeData
    {
        public string Name { get; set; }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string PreferredName { get; set; }

        public PartyTypeData PartyType { get; set; }

    }
}
