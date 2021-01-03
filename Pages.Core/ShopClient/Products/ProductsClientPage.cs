using System;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Shop.Products;

namespace MaskShop.PagesCore.ShopClient.Products
{
    public class ProductsClientPage : ProductsPage<ProductsClientPage>
    {
        public ProductsClientPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, c, p) { }

        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);

    }
}