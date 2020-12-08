using MaskShop.Data.Parties;

namespace MaskShop.Domain.Parties
{
    public sealed class PartyRole: PartyAttribute<PartyRoleData>
    {
        public PartyRole() : this(null) { }

        public PartyRole(PartyRoleData d) : base(d) { }

        public string Role => Data?.Role ?? Unspecified;
    }
}

