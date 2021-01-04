using System;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Products;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopAdmin.Products
{
    public class ProductsAdminPage : ProductsPage<ProductsAdminPage>
    {
        protected override string BasketItemsPage => "/Shop/BasketItems";

        protected internal override Uri pageUrl() => new Uri("/Client/Products", UriKind.Relative);

        public override IHtmlContent GetValue(IHtmlHelper<ProductsAdminPage> h, int i) => i switch
        {
            2 => getRaw(h, CategoryName(Item.ProductCategoryId)),
            3 => h.DisplayImageFor(Item.PictureUri),
            _ => base.GetValue(h, i)
        };
    }
}