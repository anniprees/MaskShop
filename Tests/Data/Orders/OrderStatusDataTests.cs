using Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class OrderStatusDataClassTests : SealedClassTests<OrderStatusData, UniqueEntityData>
    {
        [TestMethod] public void OrderStatusTypeTest() 
            => IsProperty(() => obj.OrderStatusType, x => obj.OrderStatusType = x);
    }
}
