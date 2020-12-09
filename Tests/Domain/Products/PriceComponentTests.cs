using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class PriceComponentTests : SealedClassTests<PriceComponent, UniqueEntity<PriceComponentData>>
    {
        protected override PriceComponent CreateObject() => new PriceComponent(GetRandom.Object<PriceComponentData>());

        [TestMethod]
        public void DiscountPercentageTest() => IsReadOnlyProperty(obj.Data.DiscountPercentage);

        [TestMethod]
        public void CommentTest() => IsReadOnlyProperty(obj.Data.Comment);

        [TestMethod]
        public void PartyRoleIdTest() => IsReadOnlyProperty(obj.Data.PartyRoleId);

        [TestMethod]
        public void PartyRoleTest() =>
            IsReadOnlyProperty(obj, nameof(obj.PartyRoleId), obj.Data.PartyRoleId);

    }
}