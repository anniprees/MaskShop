using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class PriceComponentView : UniqueEntityView
    {
        [Required] 
        [DisplayName("Comment")] public string Comment { get; set; }
        
        [Required]
        [DisplayName("Discount Percentage")] public double DiscountPercentage { get; set; }
        
        [Required]
        [DisplayName("Party Role")] public string PartyRoleId { get; set; }
    }
}
