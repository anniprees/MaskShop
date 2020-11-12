using System.ComponentModel;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductView : NamedView
    {
        [DisplayName("Product category Id")]
        public string ProductCategoryId { get; set; }
    }
}
