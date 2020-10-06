using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderItemDataTests : SealedClassTests<OrderItemData, UniqueEntityData>
    {
        [TestMethod]
        public void QuantityTest()
            => IsProperty(() => obj.Quantity, x => obj.Quantity = x);

        [TestMethod]
        public void UnitPriceTest()
            => IsProperty(() => obj.UnitPrice, x => obj.UnitPrice = x);

        [TestMethod]
        public void OrderIdTest()
            => IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);

        [TestMethod]
        public void ProductIdTest()
            => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void ProductFeatureIdTest()
            => IsNullableProperty(() => obj.ProductFeatureId, x => obj.ProductFeatureId = x);

        [TestMethod]
        public void ContactMechanismIdTest()
            => IsNullableProperty(() => obj.ContactMechanismId, x => obj.ContactMechanismId = x);

        [TestMethod]
        public void PartyRoleIdTest()
            => IsNullableProperty(() => obj.PartyRoleId, x => obj.PartyRoleId = x);
    }
}
