using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class DefinedEntityTests : AbstractClassTests<NamedEntity<ProductData>, UniqueEntity<ProductData>>
    {
        private class TestClass : NamedEntity<ProductData>
        {
            public TestClass(ProductData d = null) : base(d) { }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<ProductData>());
        }

        [TestMethod]
        public void NameTest() => IsReadOnlyProperty(obj.Name);
    }
}
