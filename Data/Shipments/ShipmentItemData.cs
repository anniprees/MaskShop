using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Shipments
{
    public sealed class ShipmentItemData : UniqueEntityData
    {
        public int Quantity { get; set; }

        public string ShipmentId { get; set; }

        public string ProductId { get; set; }
    }
}
