using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class OrderValueView : UniqueEntityView
    {
        [DisplayName("From amount")]
        [Required]
        public string FromAmount { get; set; }
    }
}
