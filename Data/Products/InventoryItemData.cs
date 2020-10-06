using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class InventoryItemData : UniqueEntityData
    {
        public int QuantityOnHand { get; set; }

        public string ProductId { get; set; }
    }
}
