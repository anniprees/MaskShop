using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeatureApplicability : Entity<ProductFeatureApplicabilityData>
    {
        public ProductFeatureApplicability(ProductFeatureApplicabilityData d) : base(d) { }
        public string ProductId => Data?.ProductId ?? Unspecified;
        public string ProductFeatureId => Data?.ProductFeatureId ?? Unspecified;

        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);

        //TODO ProductFeatureID
        //public ProductFeature ProductFeature => new GetFrom<IProductFeaturesRepository, Product>().ById(ProductFeatureId);
    }
}
