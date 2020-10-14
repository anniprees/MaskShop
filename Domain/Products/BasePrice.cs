using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class BasePrice: PriceComponent<BasePriceData>
    {
        public BasePrice() : this(null) { }

        public BasePrice(BasePriceData d) : base(d) { }
    }
}
