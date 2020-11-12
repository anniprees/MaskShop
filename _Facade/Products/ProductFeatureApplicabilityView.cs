using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public abstract class ProductFeatureApplicabilityView : PeriodView
    {
        [DisplayName("Product Id")]
        [Required]
        public string ProductId { get; set; }
        [DisplayName("Product feature Id")]
        [Required]
        public string ProductFeatureId { get; set; }
    }
}
