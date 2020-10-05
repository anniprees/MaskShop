using Data.Common;

namespace MaskShop.Data.Products
{
    public abstract class PriceComponentData : UniqueEntityData
    {
        public double Price { get; set; }

        public double Percent { get; set; }

        public string Comment { get; set; }

        public string ProductId { get; set; }

        public string ProductFeatureId { get; set; }

        public string ProductCategoryId { get; set; }

        public string ConsumerRoleTypeId { get; set; }

    }
}
