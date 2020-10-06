using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class PriceComponentDataTests : AbstractClassTests<PriceComponentData, UniqueEntityData>
    {
        private class TestClass : PriceComponentData{}

        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<TestClass>();
        }

        [TestMethod] public void PriceTest() => IsProperty(() => obj.Price, x => obj.Price = x);
        [TestMethod] public void PercentTest() => IsProperty<double>(() => obj.Percent, x => obj.Percent = x);
        [TestMethod] public void CommentTest() => IsNullableProperty<string>(() => obj.Comment, x => obj.Comment = x);
        [TestMethod] public void ProductIdTest() => IsNullableProperty<string>(() => obj.ProductId, x => obj.ProductId = x);
        [TestMethod] public void ProductFeatureIdTest() => IsNullableProperty<string>(() => obj.ProductFeatureId, x => obj.ProductFeatureId = x);
        [TestMethod] public void ProductCategoryIdTest() => IsNullableProperty<string>(() => obj.ProductCategoryId, x => obj.ProductCategoryId = x);
        [TestMethod] public void ConsumerRoleTypeIdTest() => IsNullableProperty<string>(() => obj.ConsumerRoleTypeId, x => obj.ConsumerRoleTypeId = x);
    }
}


