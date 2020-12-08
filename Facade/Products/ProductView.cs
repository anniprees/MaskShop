using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;
using Microsoft.AspNetCore.Http;

namespace MaskShop.Facade.Products
{
    public sealed class ProductView : NamedView
    {
        [Required]
        [DisplayName("Product Price")] public double Price { get; set; }

        [Required]
        [DisplayName("Product Category Id")] public string ProductCategoryId { get; set; }

        [Required]
        [DisplayName("Product feature applicability")] public string ProductFeatureApplicabilityId { get; set; }

        [DisplayName("Price Component Id")] public string PriceComponentId { get; set; }

        [DisplayName("Picture URI")] public string PictureUri { get; set; }

        [DisplayName("Picture")] public IFormFile Picture { get; set; }
    }
}
