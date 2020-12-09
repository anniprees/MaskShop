using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class FeatureSizeViewFactory
    {
        public static FeatureSize Create(FeatureSizeView v)
        {
            var d = new FeatureSizeData();
            Copy.Members(v, d);
            return new FeatureSize(d);
        }

        public static FeatureSizeView Create(FeatureSize o)
        {
            var v = new FeatureSizeView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}
