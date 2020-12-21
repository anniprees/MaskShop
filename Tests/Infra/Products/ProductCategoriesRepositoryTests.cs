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
    public class ProductCategoriesRepositoryTests : ShopDbContextTests<ProductCategoriesRepository, ProductCategory,
        ProductCategoryData>
    {

        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<ProductCategory, ProductCategoryData>);

        protected override ProductCategoriesRepository GetObject(ShopDbContext c) =>
            new ProductCategoriesRepository(c);

        protected override DbSet<ProductCategoryData> GetSet(ShopDbContext c) => c.ProductCategories;
    }
}