using System;
using System.Collections.Generic;
using MaskShop.Data.Products;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using MaskShop.PagesCore.Common.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public class ProductsPage : ViewPage<ProductsPage, IProductsRepository, Product, ProductView, ProductData>
    {
        public IEnumerable<SelectListItem> Categories { get; }

        public ProductsPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, "Products")
        {
            Categories = newItemsList<ProductCategory, ProductCategoryData>(c);
        }

        public string CategoryName(string id) => itemName(Categories, id);

        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);

        protected internal override Product toObject(ProductView v) => ProductViewFactory.Create(v);
        protected internal override ProductView toView(Product o) => ProductViewFactory.Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.ProductCategoryId);
            createColumn(x => Item.ProductFeatureApplicabilityId);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.Price);
            createColumn(x => Item.PriceComponentId);
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

        public override IHtmlContent GetValue(IHtmlHelper<ProductsPage> h, int i) => i switch
        {
            2 => getRaw(h, CategoryName(Item.ProductCategoryId)),
            5 => h.DisplayImageFor(Item.PictureUri),
            _ => base.GetValue(h, i)

        };
    }
}