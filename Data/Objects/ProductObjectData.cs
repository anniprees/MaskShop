using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Objects
{
    public sealed class ProductObjectData : PeriodData
    {
        public string ProductId { get; set; }

        public string ObjectId { get; set; }
    }
}
