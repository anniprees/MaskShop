﻿using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Data.Products
{
    public sealed class ProductFeatureApplicabilityData : UniqueEntityData
    {
        public string ProductId { get; set; }
        public string ProductFeatureId { get; set; }
    }
}
