using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public abstract class ProductFeatureApplicabilityData : PeriodData
    {
        public string ProductId { get; set; }

        public string ProductFeatureId { get; set; }
    }
}
