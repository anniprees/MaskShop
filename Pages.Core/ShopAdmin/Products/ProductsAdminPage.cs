using System;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Common.Extensions;
using MaskShop.PagesCore.Shop.Products;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.ShopAdmin.Products
{
    public class ProductsAdminPage : ProductsPage<ProductsAdminPage>
    {
        public ProductsAdminPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, c, p) { }

        protected internal override Uri pageUrl() => new Uri("/Client/Products", UriKind.Relative);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            base.createTableColumns();
            createColumn(x => Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

        public override IHtmlContent GetValue(IHtmlHelper<ProductsAdminPage> h, int i) => i switch
        {
            2 => getRaw(h, CategoryName(Item.ProductCategoryId)),
            3 => h.DisplayImageFor(Item.PictureUri),
            _ => base.GetValue(h, i)
        };

    }
}