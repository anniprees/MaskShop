using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Facade.Products
{
    public class QuantityBreakView : UniqueEntityData
    {
        [DisplayName("From quantity")]
        public string FromQuantity { get; set; }
    }
}
