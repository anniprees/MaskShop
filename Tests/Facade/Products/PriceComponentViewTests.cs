using MaskShop.Aids;
using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    [TestClass] public class PriceComponentViewTests : SealedClassTests<PriceComponentView, UniqueEntityView>
    {
        [TestMethod]
        public void DiscountPercentageTest() => IsProperty<double>("Discount Percentage");
        [TestMethod]
        public void CommentTest() => IsNullableProperty<string>("Comment");
        [TestMethod]
        public void PartyRoleIdTest() => IsNullableProperty<string>("Party Role Id");
    }
}
