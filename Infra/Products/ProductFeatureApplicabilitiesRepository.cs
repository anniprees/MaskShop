﻿using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class ProductFeatureApplicabilitiesRepository : UniqueEntityRepository<ProductFeatureApplicability, ProductFeatureApplicabilityData>
    {
        public ProductFeatureApplicabilitiesRepository(ProductDbContext c = null) : base(c, c?.ProductFeatureApplicabilities) { }

        protected override ProductFeatureApplicability ToDomainObject(ProductFeatureApplicabilityData d) => new ProductFeatureApplicability(d);
    }
}