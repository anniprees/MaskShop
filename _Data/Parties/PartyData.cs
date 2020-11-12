using MaskShop.Data.Common;

namespace MaskShop.Data.Parties
{
    public sealed class PartyData : UniqueEntityData
    {
        public string Description { get; set; }

        public string PartyNameId { get; set; }

        //public string OrganizationTypeId { get; set; }

        public PartyTypeData PartyType { get; set; }
    }
}
