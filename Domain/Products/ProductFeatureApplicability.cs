using System.Collections.Generic;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeatureApplicability : UniqueEntity<ProductFeatureApplicabilityData>
    {
        public ProductFeatureApplicability(ProductFeatureApplicabilityData d) : base(d) { }
        public string ProductId => Data?.ProductId ?? Unspecified;
        public string ProductFeatureId => Data?.ProductFeatureId ?? Unspecified;
        public IReadOnlyList<Product> Products => new GetFrom<IProductsRepository, Product>().ListBy(ProductId, Id);
        public ProductFeature ProductFeature => new GetFrom<IProductFeaturesRepository, ProductFeature>().ById(ProductFeatureId);
    }
}
