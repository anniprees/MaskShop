using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public sealed class OrderItemViewFactory 
    {
        //protected internal override OrderItem ToObject(OrderItemData d) => new OrderItem(d);

        public static OrderItem Create(OrderItemView v)
        {
            var d = new OrderItemData();
            Copy.Members(v, d);
            return new OrderItem(d);
        }

        public static OrderItemView Create(OrderItem o)
        {
            var v = new OrderItemView();
            Copy.Members(o?.Data, v);
            v.ProductName = o?.Product?.Name;
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.PictureUri = "data:image/jpg;base64," + s;
            v.UnitPrice = o?.Product?.Price ?? 0M;
            v.TotalPrice = v.UnitPrice * v.Quantity;
            //v.TotalPrice = o?.TotalPrice ?? 0M;
            return v;
        }
    }
}
