using Data.Common;

namespace MaskShop.Data.Orders
{
    public sealed class OrderData : UniqueEntityData
    {
        public string ContactMechanismId { get; set; }

        public string PartyRoleId { get; set; }
    }
}
