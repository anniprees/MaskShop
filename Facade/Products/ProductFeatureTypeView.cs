using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductFeatureCategoryView :DefinedView
    {
        [Required]
        [DisplayName("Is Mandatory Feature")]
        public bool IsMandatory { get; set; }

        [Required]
        [DisplayName("Numeric Code")]
        public int NumericCode { get; set; }
    }
}
