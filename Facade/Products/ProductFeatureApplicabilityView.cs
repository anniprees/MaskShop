using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductFeatureApplicabilityView : UniqueEntityView
    {
        [Required]
        [DisplayName("Product Feature Id")] public string ProductFeatureId { get; set; }

        [Required]
        [DisplayName("Product Id")] public string ProductId { get; set; }
    }
}
