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
    public class FeatureSizesDbContextTests : ProductDbContextTests<FeatureSizesRepository, FeatureSize,
        FeatureSizeData>
    {

        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<FeatureSize, FeatureSizeData>);

        protected override FeatureSizesRepository GetObject(ProductDbContext c) =>
            new FeatureSizesRepository(c);

        protected override DbSet<FeatureSizeData> GetSet(ProductDbContext c) => c.FeatureSizes;
    }
}