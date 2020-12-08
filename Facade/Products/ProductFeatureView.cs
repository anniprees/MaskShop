using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public abstract class ProductFeatureView : NamedView
    {
        [Required]
        [DisplayName("Product Id")] public string ProductId { get; set; }

        [Required]
        [DisplayName("Product Feature Type Id")] public string ProductFeatureTypeId { get; set; }
    }
}
