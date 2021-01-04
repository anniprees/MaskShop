using MaskShop.Data.Orders;
using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public sealed class OrderViewTests : SealedClassTests<OrderView, PartyProductsView>
    {
        [TestMethod] public void BuyerNameTest() => IsNullableProperty<string>("Buyer name");
        [TestMethod] public void ContactMechanismIdTest() => IsNullableProperty<string>("Address");
        [TestMethod] public void TotalPriceTest() => IsProperty<decimal>("Total price");
        [TestMethod] public void OrderStatusTest() => IsProperty<OrderStatus>("Order status");
    }
}
