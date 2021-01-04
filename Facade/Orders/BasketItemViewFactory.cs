using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public class BasketItemViewFactory 
    {
        protected internal BasketItem ToObject(BasketItemData d)
            => new BasketItem(d);

        public BasketItem Create(BasketItemView v)
        {
            var d = new BasketItemData();
            Copy.Members(v, d);
            return new BasketItem(d);
        }

        public BasketItemView Create(BasketItem o)
        {
            var v = new BasketItemView();
            Copy.Members(o?.Data, v);
            v.ProductName = o?.Product.Name;
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.ProductImage = "data:image/jpg;base64," + s;
            v.UnitPrice = o.Product.Price;
            v.TotalPrice = o?.TotalPrice ?? 0M;
            return v;
        }



    }
}
