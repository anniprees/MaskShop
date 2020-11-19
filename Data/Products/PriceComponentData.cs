using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class PriceComponentData : UniqueEntityData
    {
        public double Price { get; set; }
        public double DiscountComponent { get; set; }
        public string Comment { get; set; }
        public string ProductId { get; set; }
        //public string ProductFeatureId { get; set; }
        //public string ProductCategoryId { get; set; }
        public string ConsumerRoleTypeId { get; set; }
    }
}
