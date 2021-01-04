using System;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using MaskShop.PagesCore.Shop.Products;

namespace MaskShop.PagesCore.ShopClient.Products
{
    public class ProductsClientPage : ProductsPage<ProductsClientPage>, IPaging
    {
        public ProductsClientPage(IProductsRepository r, IProductCategoriesRepository c, IPriceComponentsRepository p) :
            base(r, c, p) { }

        public int PageSize { get; set; } = 100;
        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);
    }
}