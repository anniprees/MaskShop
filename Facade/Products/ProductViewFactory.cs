
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductViewFactory
    {
        public static Product Create(ProductView v)
        {
            var d = new ProductData();
            Copy.Members(v, d);
            return new Product(d);
        }

        public static ProductView Create(Product o)
        {
            var v = new ProductView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}

