using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public abstract class ProductFeatureApplicability<TData> : Entity<TData> where TData: ProductFeatureApplicabilityData, new()
    {
        public ProductFeatureApplicability(TData d= null) : base(d) { }
        public string ProductId => data?.ProductId ?? Unspecified;
        public string ProductFeatureId => data?.ProductFeatureId ?? Unspecified;
        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);
        public ProductFeature ProductFeature => new GetFrom<IProductFeaturesRepository, ProductFeature>().ById(ProductFeatureId);

    }

}
