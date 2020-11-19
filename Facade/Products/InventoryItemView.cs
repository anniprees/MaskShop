using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class InventoryItemView : UniqueEntityView
    {
        [DisplayName("Quantity on hand")]
        [Required]
        public string QuantityOnHand { get; set; }

        [DisplayName("Product Id")]
        [Required] 
        public string ProductId { get; set; }
    }
}