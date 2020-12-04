using MaskShop.Data.Common;

namespace MaskShop.Data.Orders
{
    public sealed class OrderItemData : ItemProductData
    {
        public string OrderId { get; set; }
        public string PartyRoleId { get; set; }
    }
}
