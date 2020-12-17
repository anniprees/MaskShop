using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public sealed class OrderItemViewFactory : AbstractViewFactory<OrderItemData, OrderItem, OrderItemView>
    {
        protected internal override OrderItem ToObject(OrderItemData d) => new OrderItem(d);

        public override OrderItemView Create(OrderItem o)
        {
            var v = base.Create(o);
            v.ProductName = o?.Product?.Name;
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.PictureUri = "data:image/jpg;base64," + s;
            v.UnitPrice = o?.Product?.Price ?? 0M;
            v.TotalPrice = o?.TotalPrice ?? 0M;
            return v;
        }
    }
}
