using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class QuantityBreak: UniqueEntity<QuantityBreakData>
    {
        public QuantityBreak() : this(null) { }

        public QuantityBreak(QuantityBreakData d) : base(d) { }
    }
}
