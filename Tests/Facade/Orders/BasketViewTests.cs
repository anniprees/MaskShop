using MaskShop.Facade.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Orders
{
    [TestClass]
    public class BasketViewTests : SealedClassTests<BasketView, PartyProductsView>
    {
        [TestMethod] public void PartyNameTest() => IsNullableProperty<string>("Name");

        [TestMethod] public void PartyAddressTest() => IsNullableProperty<string>("Address");

        [TestMethod] public void TotalPriceTest() => IsProperty<decimal>("Total price");
    }
}
