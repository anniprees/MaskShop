using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Data.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Orders
{
    [TestClass]
    public class BasketItemDataTests : SealedClassTests<BasketItemData, ItemProductData>
    {
        [TestMethod]
        public void BasketIdTest()
            => IsNullableProperty(() => obj.BasketId, x => obj.BasketId = x);
    }
}
