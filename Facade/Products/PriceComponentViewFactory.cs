using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class PriceComponentViewFactory
    {
        public static PriceComponent Create(PriceComponentView v)
        {
            var d = new PriceComponentData();
            Copy.Members(v, d);
            return new PriceComponent(d);
        }

        public static PriceComponentView Create(PriceComponent o)
        {
            var v = new PriceComponentView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}
