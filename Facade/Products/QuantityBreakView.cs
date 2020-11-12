using System.ComponentModel;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class QuantityBreakView : UniqueEntityView
    {
        [DisplayName("From quantity")]
        public string FromQuantity { get; set; }
    }
}
