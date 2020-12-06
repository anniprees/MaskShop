using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderItemDataTests : SealedClassTests<OrderItemData, UniqueEntityData>
    {
        [TestMethod]
        public void OrderIdTest()
            => IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);

        [TestMethod]
        public void PartyRoleIdTest()
            => IsNullableProperty(() => obj.PartyRoleId, x => obj.PartyRoleId = x);
    }
}
