﻿using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class ProductCategory : NamedEntity<ProductCategoryData>
    {
        public ProductCategory() : this(null) { }

        public ProductCategory(ProductCategoryData d) : base(d) { }
    }
}
