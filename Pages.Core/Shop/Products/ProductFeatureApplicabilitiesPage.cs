using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using MaskShop.PagesCore.Common.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public class ProductFeatureApplicabilitiesPage : ViewPage<ProductFeatureApplicabilitiesPage,
        IProductFeatureApplicabilitiesRepository, ProductFeatureApplicability, ProductFeatureApplicabilityView,
        ProductFeatureApplicabilityData>
    {
        public IEnumerable<SelectListItem> Products { get; }
        public IEnumerable<SelectListItem> ProductFeatures { get; }

        public ProductFeatureApplicabilitiesPage(IProductFeatureApplicabilitiesRepository r, IProductsRepository p,
            IProductFeaturesRepository f) :
            base(r, "Available Features")
        {
            Products = newItemsList<Product, ProductData>(p);
            ProductFeatures = newItemsList<ProductFeature, ProductFeatureData>(f);
        }

        public string ProductName(string id) => itemName(Products, id);
        public string ProductFeatureName(string id) => itemName(ProductFeatures, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/ProductFeatureAppl", UriKind.Relative);

        protected internal override ProductFeatureApplicability toObject(ProductFeatureApplicabilityView v) =>
            ProductFeatureApplicabilityViewFactory.Create(v);

        protected internal override ProductFeatureApplicabilityView toView(ProductFeatureApplicability o) =>
            ProductFeatureApplicabilityViewFactory.Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.ProductId);
            createColumn(x => Item.FeaturesCombo);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

        public override IHtmlContent GetValue(IHtmlHelper<ProductFeatureApplicabilitiesPage> h, int i) => i switch
        {
            1 => getRaw(h, ProductName(Item.ProductId)),
            _ => base.GetValue(h, i)
        };
    }
}
