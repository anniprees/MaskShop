using MaskShop.Data.Parties;

namespace MaskShop.Domain.Parties
{
    public sealed class PartyName: PartyAttribute<PartyNameData>
    {
        public PartyName() : this(null) { }

        public PartyName(PartyNameData d) : base(d) { }

        public string Name => Data?.Name ?? Unspecified;
        public string GivenName => Data?.GivenName ?? Unspecified;
        public string MiddleName => Data?.MiddleName ?? Unspecified;
        public string PreferredName => Data?.PreferredName ?? Unspecified;


    }
}

