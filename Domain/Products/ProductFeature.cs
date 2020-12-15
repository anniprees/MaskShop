﻿using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductFeature: DefinedEntity<ProductFeatureData>
    {
        public ProductFeature() : this(null) { }
        public ProductFeature(ProductFeatureData d) : base(d) { }
        public int NumericCode => Data?.NumericCode ?? UnspecifiedInteger;
    }
}