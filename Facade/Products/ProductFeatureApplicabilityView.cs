using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public abstract class ProductFeatureApplicabilityView : PeriodView
    {
        public string ProductId { get; set; }
        public string ProductFeatureId { get; set; }
    }
}
