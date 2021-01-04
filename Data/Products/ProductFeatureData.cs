using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class ProductFeatureData : DefinedEntityData
    {
        public int NumericCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}