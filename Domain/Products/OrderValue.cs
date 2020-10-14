using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class OrderValue: UniqueEntity<OrderValueData>
    {
        public OrderValue() : this(null) { }

        public OrderValue(OrderValueData d) : base(d) { }
        public double FromAmount => Data?.FromAmount ?? UnspecifiedDouble;
        
    }
}
