using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class QuantityBreakView : UniqueEntityView
    {
        [DisplayName("From quantity")]
        public string FromQuantity { get; set; }
    }
}
