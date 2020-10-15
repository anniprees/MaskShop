using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Facade.Products
{
    public class InventoryItemView : UniqueEntityData
    {
        [DisplayName("Quantity on hand")]
        [Required]
        public string QuantityOnHand { get; set; }

        [DisplayName("Product Id")]
        [Required]
        public string ProductId { get; set; }
    }
}
