using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Aids;

namespace MaskShop.Facade.Orders
{
    public sealed class BasketItemView : ItemProductView
    {
        [DisplayName("Unit price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Total price")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Basket")]
        public string BasketId { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        [DisplayName("Product image")]
        public string ProductImage { get; set; }

        public override string GetId() => Compose.Id(BasketId, ProductId);
    }
}
