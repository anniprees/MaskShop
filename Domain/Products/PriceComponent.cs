using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class PriceComponent: UniqueEntity<PriceComponentData>
    {
        public PriceComponent(PriceComponentData d) : base(d) { }
        public double Percent => Data?.DiscountPercentage ?? UnspecifiedDouble;
        public string Comment => Data?.Comment ?? Unspecified;
    }
}
