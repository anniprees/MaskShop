using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Orders;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopAdmin.Orders
{
    public class BasketItemsAdminPage : BasketItemsPage<BasketItemsAdminPage>
    {
        protected override string ordersPage => "/Shop/Orders";
        public BasketItemsAdminPage(IBasketItemsRepository r, IBasketsRepository b, IOrdersRepository o, IOrderItemsRepository oi, IProductsRepository p) 
            : base(r, b, o, oi, p) { }

        protected internal override Uri pageUrl() => new Uri("/Shop/BasketItems", UriKind.Relative);

        protected override void createTableColumns()
        {
            createColumn(x => Item.GetId());
            createColumn(x => Item.BasketId);
            createColumn(x => Item.ProductId);
            base.createTableColumns();
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

        public override string GetName(IHtmlHelper<BasketItemsAdminPage> h, int i) => i switch
        {
            0 => "Id",
            _ => base.GetName(h, i)
        };
        public override IHtmlContent GetValue(IHtmlHelper<BasketItemsAdminPage> h, int i) => i switch
        {
            0 => getRaw(h, Item.GetId()),
            4 => h.DisplayImageFor(Item.ProductImage),
            _ => base.GetValue(h, i)
        };
    }
}
