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
    public class ProductFeaturesRepositoryTests : ProductDbContextTests<ProductFeaturesRepository, ProductFeature, ProductFeatureData>
    {

        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<ProductFeature, ProductFeatureData>);

        protected override ProductFeaturesRepository GetObject(ProductDbContext c) => new ProductFeaturesRepository(c);

        protected override DbSet<ProductFeatureData> GetSet(ProductDbContext c) => c.ProductFeatures;
    }
}