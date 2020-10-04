using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Objects
{
    public sealed class FeatureObjectData : PeriodData
    {
        public string ProductFeatureId { get; set; }

        public string ObjectId { get; set; }
    }
}
