using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureApplicabilityDataTests : AbstractClassTests<ProductFeatureApplicabilityData, PeriodData> {
        private class TestClass : ProductFeatureApplicabilityData { }

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }

        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>(() => obj.ProductId, x => obj.ProductId = x);
        [TestMethod] public void ProductFeatureIdTest() => IsNullableProperty<string>(() => obj.ProductFeatureId, x => obj.ProductFeatureId = x);
    }
}


