using Data.Common;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentDataTests : SealedTests<ShipmentData, UniqueEntityData> {
        [TestMethod] public void EstimatedShipDateTest() => isProperty<DateTime>();
        [TestMethod] public void EstimatedArrivalDateTest() => isProperty<DateTime>();
        [TestMethod] public void ShipCostTest() => isNullableProperty<double>();
        [TestMethod] public void ContactMechanismIdTest() => isNullableProperty<string>();
        [TestMethod] public void PartyIdTest() => isNullableProperty<string>();
    }
}



