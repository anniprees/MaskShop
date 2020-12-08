using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Products
{
    public sealed class FeatureSizeView : ProductFeatureView
    {
        [Required]
        [DisplayName("Quantity on hand")] public string Size { get; set; }
    }
}
