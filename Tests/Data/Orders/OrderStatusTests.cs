using MaskShop.Aids;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderStatusTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => type = typeof(OrderStatus);

        [TestMethod]
        public void CountTest() 
            => Assert.AreEqual(4, GetEnum.Count<OrderStatus>());

        [TestMethod]
        public void UnspecifiedTest()
            => Assert.AreEqual(0, (int)OrderStatus.Unspecified);

        [TestMethod]
        public void ReceivedTest()
            => Assert.AreEqual(1, (int)OrderStatus.Received);

        [TestMethod]
        public void ApprovedTest()
            => Assert.AreEqual(2, (int)OrderStatus.Approved);

        [TestMethod]
        public void CanceledTest()
            => Assert.AreEqual(3, (int)OrderStatus.Canceled);
    }
}
