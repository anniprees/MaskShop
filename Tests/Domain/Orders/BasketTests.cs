using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    [TestClass]
    public class BasketTests : SealedClassTests<Basket, PartyProducts<BasketData>>
    {
        [TestMethod] public void ItemsTest() => Assert.Inconclusive();
        [TestMethod] public void TotalPriceTest() => Assert.Inconclusive();
    }
}
