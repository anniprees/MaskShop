using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Orders;

namespace MaskShop.Facade.Orders
{
    public sealed class OrderItemView : ItemProductView
    {
        [DisplayName("Product name")] 
        public string ProductName { get; set; }

        [DisplayName("Product image")] 
        public string PictureUri { get; set; }

        [DisplayName("Unit price")] 
        public decimal UnitPrice { get; set; }

        [DisplayName("Total price")] 
        public decimal TotalPrice { get; set; }

        [DisplayName("Order")]
        public string OrderId { get; set; }

        public override string GetId() => Compose.Id(OrderId, ProductId);
    }
}
