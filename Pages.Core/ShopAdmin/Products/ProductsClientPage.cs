using System;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Shop.Products;

namespace MaskShop.PagesCore.ShopAdmin.Products
{
    public class ProductsAdminPage : ProductsPage<ProductsAdminPage>
    {
        public ProductsAdminPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, c, p) { }

        protected internal override Uri pageUrl() => new Uri("/Client/Products", UriKind.Relative);

    }
}