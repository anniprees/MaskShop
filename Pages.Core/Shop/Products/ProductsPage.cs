using System.Collections.Generic;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public abstract class ProductsPage<TPage> : 
        ViewPage<TPage, IProductsRepository, Product, ProductView, ProductData> 
        where TPage : PageModel

    {
        public IEnumerable<SelectListItem> Categories { get; }

        protected ProductsPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, "Products")
        {
            Categories = newItemsList<ProductCategory, ProductCategoryData>(c);
        }

        public string CategoryName(string id) => itemName(Categories, id);

        protected internal override Product toObject(ProductView v) => new ProductViewFactory().Create(v);
        protected internal override ProductView toView(Product o) => new ProductViewFactory().Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Name);
            createColumn(x => Item.ProductCategoryId);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.Price);
        }
    }
}