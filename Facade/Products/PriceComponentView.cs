using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public class PriceComponentView : UniqueEntityView
    {
        public double Price { get; set; }

        public double Percent { get; set; }

        public string Comment { get; set; }

        public string ProductId { get; set; }

        public string ProductFeatureId { get; set; }

        public string ProductCategoryId { get; set; }

        public string ConsumerRoleTypeId { get; set; }
    }
}
