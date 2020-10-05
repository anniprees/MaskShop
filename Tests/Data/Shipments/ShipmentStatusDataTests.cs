using Data.Common;
using MaskShop.Data.Shipments;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MaskShop.Tests.Data.Shipments
{
    [TestClass]
    public class ShipmentStatusDataTests : SealedTests<ShipmentStatusData, UniqueEntityData>{
        [TestMethod] public void ShipmentStatusTypeTest() => IsProperty<ShipmentStatusTypeData>();
    }
}

