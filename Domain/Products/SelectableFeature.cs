using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class SelectableFeature: ProductFeatureApplicability<SelectableFeatureData>
    {
        public SelectableFeature() : this(null) { }

        public SelectableFeature(SelectableFeatureData d) : base(d) { }
    }
}
