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
    public class FeatureColorsRepositoryTests : ProductDbContextTests<FeatureColorsRepository, FeatureColor,
        FeatureColorData>
    {

        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<FeatureColor, FeatureColorData>);

        protected override FeatureColorsRepository GetObject(ProductDbContext c) =>
            new FeatureColorsRepository(c);

        protected override DbSet<FeatureColorData> GetSet(ProductDbContext c) => c.FeatureColors;
    }
}