using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductFeatureView : DefinedView
    {
        [DisplayName("Numeric Code")] public int NumericCode { get; set; }
    }
}