using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class FeatureSize : ProductFeature<FeatureSizeData>
    {
        public FeatureSize(FeatureSizeData d) : base(d) { }
        public string Size => Data?.Size ?? Unspecified;
    }
}
