using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductFeatureView : DefinedView
    {
        [DisplayName("Numeric Code")] public int NumericCode { get; set; }
       
        [Required(ErrorMessage = "Must specify a color")]
        [DisplayName("Color")] public string Color { get; set; }
        
        [Required(ErrorMessage = "Must specify Size")]
        [DisplayName("Size")] public string Size { get; set; }
    }
}