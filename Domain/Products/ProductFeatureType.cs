using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeatureType: DefinedEntity<ProductFeatureTypeData>
    {
        public ProductFeatureType() : this(null) { }

        public ProductFeatureType(ProductFeatureTypeData d) : base(d) { }

        public bool IsMandatory => Data?.IsMandatory ?? IsUnspecified;
        public int NumericCode => Data?.NumericCode ?? UnspecifiedInteger;
    }
}
