using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class OrderValueView : UniqueEntityView
    {
        [DisplayName("From amount")]
        [Required]
        public string FromAmount { get; set; }
    }
}
