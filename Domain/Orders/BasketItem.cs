using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Orders;
using MaskShop.Domain.Products;

namespace MaskShop.Domain.Orders
{
    public sealed class BasketItem : ItemProduct<BasketItemData>
    {
        public BasketItem(BasketItemData d) :  base(d) { }

        public string BasketId => Data?.BasketId ?? Unspecified;

        public string Id => Compose.Id(BasketId, ProductId);
    }
}
