using Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MaskShop.Data.Products
{
    public sealed class QuantityBreakData : UniqueEntityData
    {
        public int FromQuantity { get; set; }
    }
}
