using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;
using Microsoft.AspNetCore.Http;

namespace MaskShop.Facade.Products
{
    public sealed class ProductView : NamedView
    {
        [Required(ErrorMessage = "Product price is required")]
        [DisplayName("Product Price")] public decimal Price { get; set; }

        [Required(ErrorMessage = "Product category is required")]
        [DisplayName("Product Category Id")] public string ProductCategoryId { get; set; }

        [DisplayName("Product feature applicability")] public string ProductFeatureApplicabilityId { get; set; }

        [DisplayName("Price Component Id")] public string PriceComponentId { get; set; }

        [DisplayName("Picture Uri")] public string PictureUri { get; set; }

        [DisplayName("Picture")] public IFormFile PictureFile { get; set; }
    }
}
