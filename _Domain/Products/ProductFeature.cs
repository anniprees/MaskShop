using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeature: DefinedEntity<ProductFeatureData>
    {
        public ProductFeature(ProductFeatureData d = null) : base(d) { }
    }
}
