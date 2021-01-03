using MaskShop.Data.Common;

namespace MaskShop.Data.Orders
{
    public sealed class OrderData : PartyProductsData
    {
        public string ContactMechanismId { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
