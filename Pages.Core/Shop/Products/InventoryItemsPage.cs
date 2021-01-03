using System;
using System.Collections.Generic;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public class InventoryItemsPage : ViewPage<InventoryItemsPage, IInventoryItemsRepository, InventoryItem, InventoryItemView, InventoryItemData>
    {
        public IEnumerable<SelectListItem> Products { get; }

        public InventoryItemsPage(IInventoryItemsRepository r, IProductsRepository p) :
            base(r, "Inventory")
        {
            Products = newItemsList<Product, ProductData>(p);
        }

        public string ProductName(string id) => itemName(Products, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/InventoryItems", UriKind.Relative);

        protected internal override InventoryItem toObject(InventoryItemView v) => InventoryItemViewFactory.Create(v);
        protected internal override InventoryItemView toView(InventoryItem o) => InventoryItemViewFactory.Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.ProductId);
            createColumn(x => Item.QuantityOnHand);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }
        public override IHtmlContent GetValue(IHtmlHelper<InventoryItemsPage> h, int i) => i switch
        {
            1 => getRaw(h, ProductName(Item.ProductId)),
            _ => base.GetValue(h, i)
        };
    }
}
