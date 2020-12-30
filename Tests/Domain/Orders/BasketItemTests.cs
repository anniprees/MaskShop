using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    [TestClass]
    public class BasketItemTests : SealedClassTests<BasketItem, ItemProduct<BasketItemData>>
    {
        [TestMethod]
        public void BasketIdTest() => IsReadOnlyProperty(obj.Data.BasketId);

        [TestMethod]
        public void IdTest() => IsReadOnlyProperty(obj.Id);
    }
}
