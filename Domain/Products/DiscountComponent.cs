using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class DiscountComponent: PriceComponent<DiscountComponentData>
    {
        public DiscountComponent() : this(null) { }

        public DiscountComponent(DiscountComponentData d) : base(d) { }
    }
}
