using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class ProductFeatureViewTests : AbstractClassTests<ProductFeatureView, NamedView>
    {
        private class TestClass : ProductFeatureView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
    }
}
