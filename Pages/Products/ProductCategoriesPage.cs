using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.Pages.Common;

namespace MaskShop.Pages.Products
{
    public class ProductCategoriesPage : TitledPage<IProductCategoriesRepository, ProductCategory, ProductCategoryView, ProductCategoryData>
    {
        protected ProductCategoriesPage(IProductCategoriesRepository r) : base(r, "Categories") {
        }

        protected internal override ProductCategory ToObject(ProductCategoryView v) => ProductCategoryViewFactory.Create(v);

        protected internal override ProductCategoryView ToView(ProductCategory o) => ProductCategoryViewFactory.Create(o);

    }
}
