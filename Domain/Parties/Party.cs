using MaskShop.Data.Parties;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Parties
{
    public sealed class Party: NamedEntity<PartyData>
    {
        public Party(PartyData d) : base(d) { }

        public string PartyRoleId => Data?.PartyRoleId ?? Unspecified;
        public PartyRole PartyRole => new GetFrom<IPartyRolesRepository, PartyRole>().ById(PartyRoleId);

        public string ContactMechanismId => Data?.ContactMechanismId ?? Unspecified;
        public ContactMechanism ContactMechanism => new GetFrom<IContactMechanismsRepository, ContactMechanism>().ById(ContactMechanismId);

        public PartyType PartyType => Data?.PartyType ?? PartyType.Unspecified;
    }
}