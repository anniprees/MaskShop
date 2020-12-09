using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Orders;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Orders
{
    public sealed class Basket : PartyProducts<BasketData>
    {
        private readonly string _basketId = GetMember.Name<BasketItemData>(x => x.BasketId);

        public Basket(BasketData d) : base(d) { }

        public IReadOnlyList<BasketItem> Items =>
        new GetFrom<IBasketItemsRepository, BasketItem>().ListBy(_basketId, Id);

        public decimal TotalPrice
        {
            get
            {
                var sum = decimal.Zero;
                foreach (var i in Items) sum += i.TotalPrice;
                return sum;
            }
        }
    }
}
