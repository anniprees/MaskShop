using MaskShop.Data.Common;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductFeatureTests : AbstractClassTests<ProductFeatureData, NamedEntityData>
    {
        private class TestClass : ProductFeatureData { }
        
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
    }
}
