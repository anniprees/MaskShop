using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class ProductsRepository : UniqueEntityRepository<Product, ProductData>, IProductsRepository
    {
        public ProductsRepository(ShopDbContext c = null) : base(c, c?.Products) { }

        protected internal override Product ToDomainObject(ProductData d) => new Product(d);
    }
}