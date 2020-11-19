using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeatureCategory: DefinedEntity<ProductFeatureTypeData>
    {
        public ProductFeatureCategory() : this(null) { }

        public ProductFeatureCategory(ProductFeatureTypeData d) : base(d) { }
    }
}
