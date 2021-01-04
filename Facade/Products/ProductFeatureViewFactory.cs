using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductFeatureViewFactory
    {
        public static ProductFeature Create(ProductFeatureView v)
        {
            var d = new ProductFeatureData();
            Copy.Members(v, d);
            return new ProductFeature(d);
        }

        public static ProductFeatureView Create(ProductFeature o)
        {
            var v = new ProductFeatureView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}