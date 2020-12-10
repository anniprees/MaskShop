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
    public class ProductFeatureApplicabilitiesDbContextTests : ProductDbContextTests<ProductFeatureApplicabilitiesRepository, ProductFeatureApplicability, ProductFeatureApplicabilityData>
    {
        protected override Type GetBaseClass() => typeof(UniqueEntityRepository<ProductFeatureApplicability, ProductFeatureApplicabilityData>);

        protected override ProductFeatureApplicabilitiesRepository GetObject(ProductDbContext c) =>
            new ProductFeatureApplicabilitiesRepository(c);

        protected override DbSet<ProductFeatureApplicabilityData> GetSet(ProductDbContext c) => c.ProductFeatureApplicabilities;
    }
}