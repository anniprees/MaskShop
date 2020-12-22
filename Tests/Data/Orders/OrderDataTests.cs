using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderDataTests : SealedClassTests<OrderData, PartyProductsData>
    {
        [TestMethod]
        public void ContactMechanismIdTest()
            => IsNullableProperty(() => obj.ContactMechanismId, x => obj.ContactMechanismId = x);

        [TestMethod]
        public void PartyNameIdTest()
            => IsNullableProperty(() => obj.PartyNameId, x => obj.PartyNameId = x);

        [TestMethod] 
        public void OrderStatusTest() 
            => IsProperty(() => obj.OrderStatus, x => obj.OrderStatus = x);

    }
}
