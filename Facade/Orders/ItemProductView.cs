using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public abstract class ItemProductView : PeriodView
    {
        [DisplayName("Product")]
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
