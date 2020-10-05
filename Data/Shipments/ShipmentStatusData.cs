using Data.Common;

namespace MaskShop.Data.Shipments
{
    public sealed class ShipmentStatusData : UniqueEntityData
    {
        public ShipmentStatusTypeData ShipmentStatusType { get; set; }
    }
}
