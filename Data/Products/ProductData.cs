using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class ProductData : NamedEntityData
    {
        public string ProductCategoryId { get; set; }
        public string PriceComponentId { get; set; }
        public decimal Price { get; set; }
        public string ProductFeatureApplicabilityId { get; set; }
        public string PictureUri { get; set; }
        public byte[] Picture { get; set; }
    }
}
