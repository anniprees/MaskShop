using Aids;
using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureDataTests : AbstractClassTests<ProductFeatureData, DefinedEntityData> 
    {
        private class TestClass : ProductFeatureData { }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }
    }
}

