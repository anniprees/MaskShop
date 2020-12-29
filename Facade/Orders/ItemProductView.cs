using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public abstract class ItemProductView : PeriodView
    {
        [DisplayName("Product")]
        public string ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Quantity { get; set; }
    }
}
