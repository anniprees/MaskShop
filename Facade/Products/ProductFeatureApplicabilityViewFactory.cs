﻿using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductFeatureApplicabilityViewFactory
    {
        public static ProductFeatureApplicability Create(ProductFeatureApplicabilityView v)
        {
            var d = new ProductFeatureApplicabilityData();
            Copy.Members(v, d);
            return new ProductFeatureApplicability(d);
        }

        public static ProductFeatureApplicabilityView Create(ProductFeatureApplicability o)
        {
            var v = new ProductFeatureApplicabilityView();
            Copy.Members(o?.Data, v);
            v.FeaturesCombo = o?.ProductFeature.ToString();
            return v;
        }
    }
}
