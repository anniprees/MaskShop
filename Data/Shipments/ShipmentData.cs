using Data.Common;
using System;

namespace MaskShop.Data.Shipments
{
    public sealed class ShipmentData : UniqueEntityData
    {
        public DateTime EstimatedShipDate { get; set; }

        public DateTime EstimatedArrivalDate { get; set; }

        public double ShipCost { get; set; }

        public string ContactMechanismId { get; set; }

        public string PartyId { get; set; }


    }
}
