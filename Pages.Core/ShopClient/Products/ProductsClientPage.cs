using System;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Products;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopClient.Products
{
    public class ProductsClientPage : ProductsPage<ProductsClientPage>, IPaging
    {
        protected override string BasketItemsPage => "/Client/BasketItems";

        public ProductsClientPage(IProductsRepository r, IProductCategoriesRepository c, IBasketsRepository b, IBasketItemsRepository bi) 
            : base(r, c, b, bi) { }

        public int PageSize { get; set; } = 100;
        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);
    }
}