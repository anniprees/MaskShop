using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public abstract class ProductFeatureData : NamedEntityData
    {
        public string ProductFeatureTypeId { get; set; }
    }
}