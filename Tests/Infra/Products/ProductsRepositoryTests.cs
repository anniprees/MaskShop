using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;
using MaskShop.Infra.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Products
{
    [TestClass]
    public class ProductsRepositoryTests : ProductRepositoryTests<ProductsRepository, Product, ProductData>
    {

        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<Product, ProductData>);

        protected override ProductsRepository GetObject(ProductDbContext c) => new ProductsRepository(c);

        protected override DbSet<ProductData> GetSet(ProductDbContext c) => c.Products;
    }
}