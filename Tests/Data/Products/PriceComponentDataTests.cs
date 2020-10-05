using Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class PriceComponentDataTests : AbstractClassTests<PriceComponentData, UniqueEntityData> {
        [TestMethod] public void PriceTest() => IsNullableProperty<double>();
        [TestMethod] public void PercentTest() => IsNullableProperty<double>();
        [TestMethod] public void CommentTest() => IsNullableProperty<string>();
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ProductFeatureIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ProductCategoryIdTest() => IsNullableProperty<string>();
        [TestMethod] public void ConsumerRoleTypeIdTest() => IsNullableProperty<string>();
    }
}


