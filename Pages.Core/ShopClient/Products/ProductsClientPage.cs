using System;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Products;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopClient.Products
{
    public class ProductsClientPage : ProductsPage<ProductsClientPage>, IPaging
    {
        public ProductsClientPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, c, p) { }

        public int PageSize { get; set; } = 100;
        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);
        

        public override IHtmlContent GetValue(IHtmlHelper<ProductsClientPage> h, int i) => i switch
        {
            1 => getRaw(h, CategoryName(Item.ProductCategoryId)),
            2 => h.DisplayImageFor(Item.PictureUri),
            _ => base.GetValue(h, i)
        };
    }
}