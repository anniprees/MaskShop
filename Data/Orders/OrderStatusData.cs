using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Orders
{
    public sealed class OrderStatusData : UniqueEntityData
    {
        public OrderStatusTypeData OrderStatusType { get; set; }
    }
}
