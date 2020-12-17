using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public sealed class BasketItemViewFactory : AbstractViewFactory<BasketItemData, BasketItem, BasketItemView>
    {
        protected internal override BasketItem ToObject(BasketItemData d)
            => new BasketItem(d);

        public override BasketItemView Create(BasketItem o)
        {
            var v = base.Create(o);
            v.ProductName = o.Product.Name;
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.ProductImage = "data:image/jpg;base64," + s;
            v.UnitPrice = o.Product.Price;
            v.TotalPrice = o.TotalPrice;
            return v;
        }
    }
}
