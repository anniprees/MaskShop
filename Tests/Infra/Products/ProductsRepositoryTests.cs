using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra;
using MaskShop.Infra.Common;
using MaskShop.Infra.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Products
{
    [TestClass]
    public class ProductsRepositoryTests : ShopDbContextTests<ProductsRepository, Product, ProductData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<Product, ProductData>);

        protected override ProductsRepository GetObject(ShopDbContext c) => new ProductsRepository(c);

        protected override DbSet<ProductData> GetSet(ShopDbContext c) => c.Products;
    }
}