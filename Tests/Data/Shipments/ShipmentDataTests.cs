using Data.Common;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentDataTests : SealedTests<ShipmentData, UniqueEntityData> {
        [TestMethod] public void EstimatedShipDateTest() => IsProperty<DateTime>();
        [TestMethod] public void EstimatedArrivalDateTest() => IsProperty<DateTime>();
        [TestMethod] public void ShipCostTest() => IsNullableProperty<double>();
        [TestMethod] public void ContactMechanismIdTest() => IsNullableProperty<string>();
        [TestMethod] public void PartyIdTest() => IsNullableProperty<string>();
    }
}



