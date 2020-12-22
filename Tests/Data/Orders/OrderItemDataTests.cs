using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderItemDataTests : SealedClassTests<OrderItemData, ItemProductData>
    {
        [TestMethod]
        public void OrderIdTest()
            => IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);
    }
}
