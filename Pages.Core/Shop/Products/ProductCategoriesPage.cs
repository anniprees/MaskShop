using System;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaskShop.PagesCore.Shop.Products
{
    public class ProductCategoriesPage : ViewPage<ProductCategoriesPage, IProductCategoriesRepository, ProductCategory, ProductCategoryView, ProductCategoryData>
    {
        public ProductCategoriesPage(IProductCategoriesRepository r) : base(r, "Categories") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/ProductCategories", UriKind.Relative);

        protected internal override ProductCategory toObject(ProductCategoryView v) => ProductCategoryViewFactory.Create(v);

        protected internal override ProductCategoryView toView(ProductCategory o) => ProductCategoryViewFactory.Create(o);
        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
        }
    }
}