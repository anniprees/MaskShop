using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class PriceComponentDataTests : AbstractTests<PriceComponentData, UniqueEntityData> {
        [TestMethod] public void PriceTest() => isNullableProperty<double>();
        [TestMethod] public void PercentTest() => isNullableProperty<double>();
        [TestMethod] public void CommentTest() => isNullableProperty<string>();
        [TestMethod] public void ProductIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductFeatureIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductCategoryIdTest() => isNullableProperty<string>();
        [TestMethod] public void ConsumerRoleTypeIdTest() => isNullableProperty<string>();
    }
}


