using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Parties;

namespace MaskShop.Domain.Products
{
    public sealed class PriceComponent: UniqueEntity<PriceComponentData>
    {
        public PriceComponent(PriceComponentData d) : base(d) { }
        public double DiscountPercentage => Data?.DiscountPercentage ?? UnspecifiedDouble;
        public string Comment => Data?.Comment ?? Unspecified;
        public string PartyRoleId => Data?.PartyRoleId ?? Unspecified;
        public PartyRole PartyRole => new GetFrom<IPartyRolesRepository, PartyRole>().ById(PartyRoleId);
    }
}
