using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public interface IProduct : IUniqueEntity<ProductData>
    {
        string ProductCategoryId { get; }
        ProductCategory ProductCategory { get; }
    }
}
