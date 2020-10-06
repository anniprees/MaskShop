using MaskShop.Aids;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderStatusTypeDataTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize() => type = typeof(OrderStatusTypeData);

        [TestMethod]
        public void CountTest() 
            => Assert.AreEqual(3, GetEnum.Count<OrderStatusTypeData>());

        [TestMethod]
        public void ReceivedTest()
            => Assert.AreEqual(0, (int)OrderStatusTypeData.Received);

        [TestMethod]
        public void ApprovedTest()
            => Assert.AreEqual(1, (int)OrderStatusTypeData.Approved);

        [TestMethod]
        public void CanceledTest()
            => Assert.AreEqual(2, (int)OrderStatusTypeData.Canceled);
    }
}
