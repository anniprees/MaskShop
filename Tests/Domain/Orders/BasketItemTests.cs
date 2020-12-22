using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Orders
{
    public class BasketItemTests : SealedClassTests<BasketItem, ItemProduct<BasketItemData>>
    {
        [TestMethod]
        public void BasketIdTest() => IsReadOnlyProperty(obj.Data.BasketId);
    }
}
