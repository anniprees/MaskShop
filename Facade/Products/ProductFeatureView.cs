using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductFeatureView : DefinedView
    {
        [Required]
        [DisplayName("Product Id")]
        public string ProductId { get; set; }

        [Required]
        [DisplayName("Product Feature Type Id")]
        public string ProductFeatureTypeId { get; set; }
    }
}
