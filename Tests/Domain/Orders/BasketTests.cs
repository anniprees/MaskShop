using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;

namespace MaskShop.Tests.Domain.Orders
{
    public class BasketTests : SealedClassTests<Basket, PartyProducts<BasketData>>
    {
    }
}
