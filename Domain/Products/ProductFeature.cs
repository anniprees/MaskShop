using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeature: NamedEntity<ProductFeatureData>
    {
        public ProductFeature(ProductFeatureData d = null) : base(d) { }
    }
}
