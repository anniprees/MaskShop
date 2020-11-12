using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductView : NamedView
    {
        [Required]
        [DisplayName("Product category")]
        public string ProductCategoryId { get; set; }
    }
}
