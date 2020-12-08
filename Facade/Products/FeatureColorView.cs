using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Products
{
    public sealed class FeatureColorView : ProductFeatureView
    {
        [Required]
        [DisplayName("Color Code")] public int ColorCode { get; set; }
    }
}
