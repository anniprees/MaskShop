﻿using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class ProductFeatureApplicabilitiesRepository : 
        UniqueEntityRepository<ProductFeatureApplicability, ProductFeatureApplicabilityData>, IProductFeatureApplicabilitiesRepository
    {
        public ProductFeatureApplicabilitiesRepository(ShopDbContext c = null) : base(c, c?.ProductFeatureApplicabilities) { }

        protected internal override ProductFeatureApplicability ToDomainObject(ProductFeatureApplicabilityData d) => new ProductFeatureApplicability(d);
    }
}