﻿using MaskShop.Aids;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentStatusTypeDataTests: BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(ShipmentStatus);

        [TestMethod]
        public void CountTest()
        => Assert.AreEqual(5, GetEnum.Count<ShipmentStatus>());

        [TestMethod]
        public void ScheduledTest() =>
        Assert.AreEqual(0, (int)ShipmentStatus.Scheduled);

        [TestMethod]
        public void ShippedTest() =>
        Assert.AreEqual(1, (int)ShipmentStatus.Shipped);

        [TestMethod]
        public void InRouteTest() =>
        Assert.AreEqual(2, (int)ShipmentStatus.InRoute);

        [TestMethod]
        public void DeliveredTest() =>
        Assert.AreEqual(3, (int)ShipmentStatus.Delivered);
        
        [TestMethod]
        public void CanceledTest() =>
        Assert.AreEqual(4, (int)ShipmentStatus.Canceled);
    }
}


