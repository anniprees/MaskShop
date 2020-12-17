using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class ProductCategoriesRepository : UniqueEntityRepository<ProductCategory, ProductCategoryData>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(ShopDbContext c = null) : base(c, c?.ProductCategories) { }

        protected internal override ProductCategory ToDomainObject(ProductCategoryData d) => new ProductCategory(d);
    }
}