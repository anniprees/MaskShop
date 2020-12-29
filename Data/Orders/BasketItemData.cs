using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Products;

namespace MaskShop.Data.Orders
{
    public sealed class BasketItemData : ItemProductData
    {
        public string BasketId { get; set; }
    }
}
