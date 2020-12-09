using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class FeatureColorViewFactory
    {
        public static FeatureColor Create(FeatureColorView v)
        {
            var d = new FeatureColorData();
            Copy.Members(v, d);
            return new FeatureColor(d);
        }

        public static FeatureColorView Create(FeatureColor o)
        {
            var v = new FeatureColorView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}
