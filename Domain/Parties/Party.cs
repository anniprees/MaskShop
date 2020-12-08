using MaskShop.Data.Parties;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Parties
{
    public sealed class Party: UniqueEntity<PartyData>
    {
        public Party(PartyData d) : base(d) { }

        public string PartyNameId => Data?.PartyNameId ?? Unspecified;
        public PartyName PartyName => new GetFrom<IPartyNamesRepository, PartyName>().ById(PartyNameId);

        public string PartyRoleId => Data?.PartyRoleId ?? Unspecified;
        public PartyRole PartyRole => new GetFrom<IPartyRolesRepository, PartyRole>().ById(PartyRoleId);

        public string ContactMechanismId => Data?.ContactMechanismId ?? Unspecified;
        public ContactMechanism ContactMechanism => new GetFrom<IContactMechanismsRepository, ContactMechanism>().ById(ContactMechanismId);

        public PartyTypeData PartyType => Data?.PartyType ?? PartyTypeData.Unspecified;

    }
}



