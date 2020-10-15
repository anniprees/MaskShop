using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductView : NamedView
    {
        [DisplayName("Product Category")]
        public string ProductCategoryId { get; set; }
    }
}
