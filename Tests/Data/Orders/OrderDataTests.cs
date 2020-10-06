using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderDataTests : SealedClassTests<OrderData, UniqueEntityData>
    {
        [TestMethod]
        public void ContactMechanismIdTest()
            => IsNullableProperty(() => obj.ContactMechanismId, x => obj.ContactMechanismId = x);

        [TestMethod]
        public void PartyRoleIdTest()
            => IsNullableProperty(() => obj.PartyRoleId, x => obj.PartyRoleId = x);
    }
}
