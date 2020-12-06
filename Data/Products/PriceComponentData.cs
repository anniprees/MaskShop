using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class PriceComponentData : UniqueEntityData
    {
        public double DiscountPercentage { get; set; }
        public string Comment { get; set; }
        public string PartyRoleId { get; set; }
    }
}
