using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureApplicabilityDataTests : AbstractClassTests<ProductFeatureApplicabilityData, PeriodData> {
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ProductFeatureIdTest() => IsNullableProperty<string>();
    }
}


