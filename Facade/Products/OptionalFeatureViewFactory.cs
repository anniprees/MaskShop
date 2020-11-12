using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class OptionalFeatureViewFactory
    {
        public static OptionalFeatureView Create(OptionalFeature o)
        {
            var v = new OptionalFeatureView();
            Copy.Members(o.Data, v);
            return v;
        }
        public static OptionalFeature Create(OptionalFeatureView v)
        {
            var d = new OptionalFeatureData();
            Copy.Members(v, d);
            return new OptionalFeature(d);
        }
    }

}