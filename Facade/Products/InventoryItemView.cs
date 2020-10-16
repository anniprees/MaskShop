using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MaskShop.Data.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public class InventoryItemView : UniqueEntityView
    {
        [DisplayName("Quantity on hand")]
        [Required]
        public string QuantityOnHand { get; set; }

        [DisplayName("Product Id")]
        [Required]
        public string ProductId { get; set; }
    }
}
