using Data.Common;

namespace MaskShop.Data.Objects
{
    public sealed class FeatureObjectData : PeriodData
    {
        public string ProductFeatureId { get; set; }

        public string ObjectId { get; set; }
    }
}
