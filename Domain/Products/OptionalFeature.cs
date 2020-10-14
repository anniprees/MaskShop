using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class OptionalFeature: ProductFeatureApplicability<OptionalFeatureData>
    {
        public OptionalFeature() : this(null) { }

        public OptionalFeature(OptionalFeatureData d) : base(d) { }
    }
}
