using System;
using System.Collections.Generic;
using System.Linq;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.Infra.Products;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public class InventoryItemsPage : ViewPage<InventoryItemsPage, IInventoryItemsRepository, InventoryItem, InventoryItemView, InventoryItemData>
    {
        public IEnumerable<SelectListItem> Products { get; }
        public IEnumerable<SelectListItem> ProductFeatures { get; }

        public InventoryItemsPage(IInventoryItemsRepository r, IProductsRepository p, IProductFeaturesRepository f, IProductFeatureApplicabilitiesRepository pfa)
            : base(r, "Inventory")
        {
            Products = newItemsList<Product, ProductData>(p);
            ProductFeatures = CreateFeatureSelect(pfa);
        }

        public string ProductName(string id) => itemName(Products, id);
        public string FeatureName(string id) => itemName(ProductFeatures, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/InventoryItems", UriKind.Relative);

        protected internal override InventoryItem toObject(InventoryItemView v) => InventoryItemViewFactory.Create(v);
        protected internal override InventoryItemView toView(InventoryItem o) => InventoryItemViewFactory.Create(o);
        protected internal static IEnumerable<SelectListItem> CreateFeatureSelect(IRepository<ProductFeatureApplicability> r)
        {
            var items = r.Get().GetAwaiter().GetResult();
            return items.Select(m => new SelectListItem(m.FeatureCombo, m.Data.Id)).ToList();
        }

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.ProductId);
            createColumn(x => Item.ProductFeatureApplicabilityId);
            createColumn(x => Item.QuantityOnHand);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
            createColumn(x => Item.FeatureCombo);
        }
        public override IHtmlContent GetValue(IHtmlHelper<InventoryItemsPage> h, int i) => i switch
        {
            1 => getRaw(h, ProductName(Item.ProductId)),
            2 => getRaw(h, ProductName(Item.ProductFeatureApplicabilityId)),
            _ => base.GetValue(h, i)
        };
    }
}
