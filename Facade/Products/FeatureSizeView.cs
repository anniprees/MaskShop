using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Products
{
    public sealed class FeatureSizeView : ProductFeatureView
    {
        [Required]
        [DisplayName("Size")] public string Size { get; set; }
    }
}
