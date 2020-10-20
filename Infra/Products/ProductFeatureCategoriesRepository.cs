using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class ProductFeatureCategoriesRepository : UniqueEntityRepository<ProductFeatureCategory, ProductFeatureCategoryData>, IProductFeatureCategoriesRepository
    {
        public ProductFeatureCategoriesRepository(ProductDbContext c = null) : base(c, c?.ProductFeatureCategories) { }

        protected override ProductFeatureCategory ToDomainObject(ProductFeatureCategoryData d) => new ProductFeatureCategory(d);
    }
}
