using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    [TestClass]
    public class OrderTests : SealedClassTests<Order, PartyProducts<OrderData>>
    {
        [TestMethod]
        public void ContactMechanismIdTest() => IsReadOnlyProperty(obj.Data.ContactMechanismId);

        [TestMethod]
        public void PartyNameIdTest() => IsReadOnlyProperty(obj.Data.PartyNameId);

        [TestMethod]
        public void ContactMechanismTest() =>
            IsReadOnlyProperty(obj, nameof(obj.ContactMechanismId), obj.Data.ContactMechanismId);

        [TestMethod]
        public void PartyNameTest() =>
            IsReadOnlyProperty(obj, nameof(obj.PartyNameId), obj.Data.PartyNameId);

        [TestMethod]
        public void OrderStatusTest() =>
            IsReadOnlyProperty(obj, nameof(obj.OrderStatus), obj.Data.OrderStatus);

        [TestMethod]
        public void ItemsTest()
        {
            GetListFromRepository<OrderItem, OrderItemData, IOrderItemsRepository>(
                d => d.OrderId = obj.Id, d => new OrderItem(d));
        }

        [TestMethod]
        public void TotalPriceTest() => Assert.Inconclusive();
    }
}
