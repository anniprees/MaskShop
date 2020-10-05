using Data.Common;

namespace MaskShop.Data.Orders
{
    public sealed class OrderItemData : UniqueEntityData
    {
        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public string ProductFeatureId { get; set; }

        public string ContactMechanismId { get; set; }

        public string PartyRoleId { get; set; }
    }
}
