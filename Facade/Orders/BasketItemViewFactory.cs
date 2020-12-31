using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public static class BasketItemViewFactory 
    {
        //protected internal override BasketItem ToObject(BasketItemData d)
        //    => new BasketItem(d);

        public static BasketItem Create(BasketItemView v)
        {
            var d = new BasketItemData();
            Copy.Members(v, d);
            return new BasketItem(d);
        }

        public static BasketItemView Create(BasketItem o)
        {
            var v = new BasketItemView();
            Copy.Members(o?.Data, v);
            v.ProductId = o?.Product.Name;
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.ProductImage = "data:image/jpg;base64," + s;
            v.UnitPrice = o.Product.Price;
            v.TotalPrice = v.UnitPrice * v.Quantity;
            return v;
        }



    }
}
