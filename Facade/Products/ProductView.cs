using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;
using Microsoft.AspNetCore.Http;

namespace MaskShop.Facade.Products
{
    public sealed class ProductView : NamedView
    {
        [Required]
        [DisplayName("Product category")]
        public string ProductCategoryId { get; set; }
        [DisplayName("Picture")] public string PictureUri { get; set; }
        [DisplayName("Picture")] public IFormFile PictureFile { get; set; }
        public double Price { get; set; }

    }
}
