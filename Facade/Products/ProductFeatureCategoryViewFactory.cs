using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductFeatureCategoryViewFactory
    {
        public static ProductFeatureCategoryView Create(ProductFeatureCategory o)
        {
            var v = new ProductFeatureCategoryView();
            Copy.Members(o.Data, v);

            return v;
        }

        public static ProductFeatureCategory Create(ProductFeatureCategoryView v)
        {
            var d = new ProductFeatureCategoryData();
            Copy.Members(v, d);

            return new ProductFeatureCategory(d);
        }

    }

}