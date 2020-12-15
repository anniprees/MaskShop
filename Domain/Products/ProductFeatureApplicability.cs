using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeatureApplicability : UniqueEntity<ProductFeatureApplicabilityData>
    {
        public ProductFeatureApplicability(ProductFeatureApplicabilityData d) : base(d) { }
        public string ProductId => Data?.ProductId ?? Unspecified;
        public string ProductFeatureId => Data?.ProductFeatureId ?? Unspecified;

        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);
        public ProductFeature ProductFeature => new GetFrom<IProductFeaturesRepository, ProductFeature>().ById(ProductFeatureId);
    }
}
