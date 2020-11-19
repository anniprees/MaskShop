using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class ProductFeatureData : NamedEntityData
    {
        public string ProductId { get; set; }

        public string ProductFeatureTypeId { get; set; }
    }
}