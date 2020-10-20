using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductCategoryViewFactory
    {
        public static ProductCategoryView Create(ProductCategory o)
        {
            var v = new ProductCategoryView();
            Copy.Members(o.Data, v);

            return v;
        }

        public static ProductCategory Create(ProductCategoryView v)
        {
            var d = new ProductCategoryData();
            Copy.Members(v, d);

            return new ProductCategory(d);
        }

    }

}
