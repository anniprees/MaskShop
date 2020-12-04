using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Data.Orders
{
    public abstract class ItemProductData : PeriodData
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
