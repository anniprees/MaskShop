using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Products
{
    public abstract class ProductFeatureApplicabilityData : PeriodData
    {
        public string ProductId { get; set; }

        public string ProductFeatureId { get; set; }
    }
}
