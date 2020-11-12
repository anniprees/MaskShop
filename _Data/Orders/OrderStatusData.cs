using MaskShop.Data.Common;

namespace MaskShop.Data.Orders
{
    public sealed class OrderStatusData : UniqueEntityData
    {
        public OrderStatusTypeData OrderStatusType { get; set; }
    }
}
