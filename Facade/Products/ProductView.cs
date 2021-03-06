﻿using System.ComponentModel;
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
        [DisplayName("Product Category")] public string ProductCategoryId { get; set; }

        [DisplayName("Price Component")] public string PriceComponentId { get; set; }

        [DisplayName("Picture")] public string PictureUri { get; set; }

        [DisplayName("Picture")] public IFormFile PictureFile { get; set; }
    }
}
