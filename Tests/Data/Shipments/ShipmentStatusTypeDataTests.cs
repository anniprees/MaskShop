using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentStatusTypeDataTests: BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ShipmentStatusTypeData);

        [TestMethod]
        public void CountTest()
        => Assert.AreEqual(5, GetEnum.Count<ShipmentStatusTypeData>());

        [TestMethod]
        public void ScheduledTest() =>
        Assert.AreEqual(0, (int)ShipmentStatusTypeData.Scheduled);

        [TestMethod]
        public void ShippedTest() =>
        Assert.AreEqual(1, (int)ShipmentStatusTypeData.Shipped);

        [TestMethod]
        public void InRouteTest() =>
        Assert.AreEqual(2, (int)ShipmentStatusTypeData.InRoute);

        [TestMethod]
        public void DeliveredTest() =>
        Assert.AreEqual(3, (int)ShipmentStatusTypeData.Delivered);
        [TestMethod]
        public void CanceledTest() =>
        Assert.AreEqual(4, (int)ShipmentStatusTypeData.Canceled);
    }
}


