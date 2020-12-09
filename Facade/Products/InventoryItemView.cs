using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class InventoryItemView : UniqueEntityView
    {
        [Required] 
        [DisplayName("Quantity on hand")] public int QuantityOnHand { get; set; }
        
        [Required]
        [DisplayName("Product Id")]  public string ProductId { get; set; }
    }
}