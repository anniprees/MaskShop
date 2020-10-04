using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Products
{
    public sealed class InventoryItemData : UniqueEntityData
    {
        public int QuantityOnHand { get; set; }

        public string ProductId { get; set; }
    }
}
