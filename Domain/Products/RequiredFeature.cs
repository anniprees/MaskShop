using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class RequiredFeature: ProductFeatureApplicability<RequiredFeatureData>
    {
        public RequiredFeature() : this(null) { }

        public RequiredFeature(RequiredFeatureData d) : base(d) { }
    }
}
