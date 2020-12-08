using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Products
{
    public sealed class FeatureColorView : ProductFeatureView
    {
        [Required]
        [DisplayName("Quantity on hand")] public int ColorCode { get; set; }
    }
}
