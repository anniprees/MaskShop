using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Data.Orders;

namespace MaskShop.Facade.Orders
{
    public sealed class OrderView : PartyProductsView
    {
        [DisplayName("Buyer name")]
        public string BuyerName { get; set; }

        [DisplayName("Address")]
        public string ContactMechanismId { get; set; }

        [DisplayName("Total price")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Order status")]
        public OrderStatus OrderStatus { get; set; }

    }
}
