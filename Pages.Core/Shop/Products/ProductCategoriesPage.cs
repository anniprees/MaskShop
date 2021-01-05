using System;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public class ProductCategoriesPage : ViewPage<ProductCategoriesPage, IProductCategoriesRepository, ProductCategory, ProductCategoryView, ProductCategoryData>
    {
        public ProductCategoriesPage(IProductCategoriesRepository r) : base(r, "Categories") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/ProductCategories", UriKind.Relative);

        protected internal override ProductCategory toObject(ProductCategoryView v) => ProductCategoryViewFactory.Create(v);

        protected internal override ProductCategoryView toView(ProductCategory o) => ProductCategoryViewFactory.Create(o);

        public virtual async Task<IActionResult> OnGetSelectAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue)
        {
            var name = GetMember.Name<ProductData>(x => x.ProductCategoryId);
            var page = "/Shop/Products";
            var url = new Uri($"{page}/Index?handler=Index&fixedFilter={name}&fixedValue={id}",
                UriKind.Relative);
            await Task.CompletedTask.ConfigureAwait(false);
            return Redirect(url.ToString());
        }

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x=> Item.ValidFrom);
            createColumn(x => Item.ValidTo);
        }

    }
}