using MaskShop.Aids;
using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class PriceComponentViewTests : SealedClassTests<PriceComponentView, UniqueEntityView>
    {
        [TestMethod]
        public void PriceTest() => IsProperty<double>("Price");
        [TestMethod]
        public void PercentTest() => IsProperty<double>("Percent");
        [TestMethod]
        public void CommentTest() => IsNullableProperty<string>("Comment");
        [TestMethod]
        public void ProductIdTest() => IsNullableProperty<string>("Product Id");
        [TestMethod]
        public void ProductFeatureIdTest() => IsNullableProperty<string>("Product feature Id");
        [TestMethod]
        public void ProductCategoryIdTest() => IsNullableProperty<string>("Product category Id");
        [TestMethod]
        public void ConsumerRoleTypeIdTest() => IsNullableProperty<string>("Consumer role type Id");
    }
}
