using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class FeatureColor: ProductFeature<FeatureColorData>
    {
        public FeatureColor(FeatureColorData d) : base(d) { }
        public int ColorCode => Data?.ColorCode ?? UnspecifiedInteger;
    }
}
