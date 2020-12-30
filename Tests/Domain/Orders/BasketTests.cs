using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    [TestClass]
    public class BasketTests : SealedClassTests<Basket, PartyProducts<BasketData>>
    {
        [TestMethod]
        public void ItemsTest()
        {
            GetListFromRepository<BasketItem, BasketItemData, IBasketItemsRepository>(
                d => d.BasketId = obj.Id, d=> new BasketItem(d));
        }

        [TestMethod]
        public void TotalPriceTest() => Assert.Inconclusive();
    }
}
