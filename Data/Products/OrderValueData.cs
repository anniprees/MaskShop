using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Products
{
    public sealed class OrderValueData : UniqueEntityData
    {
        public double FromAmount { get; set; }
    }
}
