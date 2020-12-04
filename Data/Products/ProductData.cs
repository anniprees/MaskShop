using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class ProductData : NamedEntityData
    {
        public string ProductCategoryId { get; set; }
        public string ProductFeatureId { get; set; }
        public string PriceComponentId { get; set; }
        public double Price { get; set; }
    }
}
