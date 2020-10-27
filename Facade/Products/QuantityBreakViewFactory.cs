
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class QuantityBreakViewFactory
    {
        public static QuantityBreak Create(QuantityBreakView v)
        {
            var d = new QuantityBreakData();
            Copy.Members(v, d);
            return new QuantityBreak(d);
        }

        public static QuantityBreakView Create(QuantityBreak o)
        {
            var v = new QuantityBreakView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}
