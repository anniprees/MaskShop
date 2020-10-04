using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Shipments
{
    public sealed class ShipmentStatusData : UniqueEntityData
    {
        public ShipmentStatusTypeData ShipmentStatusType { get; set; }
    }
}
