using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MaskShop.Data.Common;

namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentDataTests : SealedClassTests<ShipmentData, UniqueEntityData> 
    {
        [TestMethod] public void EstimatedShipDateTest() => IsProperty<DateTime>(() => obj.EstimatedShipDate, x => obj.EstimatedShipDate = x);
        [TestMethod] public void EstimatedArrivalDateTest() => IsProperty<DateTime>(() => obj.EstimatedArrivalDate, x => obj.EstimatedArrivalDate = x);
        [TestMethod] public void ShipCostTest() => IsProperty<double>(() => obj.ShipCost, x => obj.ShipCost = x);
        [TestMethod] public void ContactMechanismIdTest() => IsNullableProperty<string>(() => obj.ContactMechanismId, x => obj.ContactMechanismId = x);
        [TestMethod] public void PartyIdTest() => IsNullableProperty<string>(() => obj.PartyId, x => obj.PartyId = x);
    }
}



