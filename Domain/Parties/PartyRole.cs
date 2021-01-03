using MaskShop.Data.Parties;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Parties
{
    public sealed class PartyRole: UniqueEntity<PartyRoleData>
    {
        public PartyRole() : this(null) { }

        public PartyRole(PartyRoleData d) : base(d) { }

        public string Role => Data?.Role ?? Unspecified;
    }
}

