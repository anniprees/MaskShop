using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeatureCategory: DefinedEntity<ProductFeatureCategoryData>
    {
        public ProductFeatureCategory() : this(null) { }

        public ProductFeatureCategory(ProductFeatureCategoryData d) : base(d) { }
    }
}
