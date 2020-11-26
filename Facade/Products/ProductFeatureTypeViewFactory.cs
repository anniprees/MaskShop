
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductFeatureTypeViewFactory
    {
        public static ProductFeatureType Create(ProductFeatureTypeView v)
        {
            var d = new ProductFeatureTypeData();
            Copy.Members(v, d);
            return new ProductFeatureType(d);
        }

        public static ProductFeatureTypeView Create(ProductFeatureType o)
        {
            var v = new ProductFeatureTypeView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}
