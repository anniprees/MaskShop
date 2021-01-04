using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Common
{
    [TestClass]
    public class UniqueEntityRepositoryTests : AbstractClassTests<UniqueEntityRepository<Product, ProductData>,
        PaginatedRepository<Product, ProductData>>
    {

        private class TestClass : UniqueEntityRepository<Product, ProductData>
        {
            public TestClass(DbContext c, DbSet<ProductData> s) : base(c, s) { }
            protected internal override Product ToDomainObject(ProductData d) => new Product(d);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(null, null);
        }

    }

}
