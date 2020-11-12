using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class StandardFeature: ProductFeatureApplicability<StandardFeatureData>
    {
        public StandardFeature() : this(null) { }

        public StandardFeature(StandardFeatureData d) : base(d) { }
    }
}
