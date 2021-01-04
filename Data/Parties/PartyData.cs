using MaskShop.Data.Common;

namespace MaskShop.Data.Parties
{
    public sealed class PartyData : NamedEntityData
    {
       public string PartyRoleId { get; set; }
        public string ContactMechanismId { get; set; }
        public PartyType PartyType { get; set; }
    }
}
