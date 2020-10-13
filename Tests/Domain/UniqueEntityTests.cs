using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain
{
    [TestClass]
    public class UniqueEntityTests : AbstractClassTests<UniqueEntity<ProductData>, Entity<ProductData>>
    {
        private class TestClass : UniqueEntity<ProductData>
        {
            public TestClass(ProductData d = null) : base(d) {}
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<ProductData>());
        }

        [TestMethod]
        public void IdTest() => isReadOnlyProperty(obj.Id);
    }
}
