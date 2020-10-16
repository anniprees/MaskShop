﻿using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class ProductFeaturesRepository : UniqueEntityRepository<ProductFeature, ProductFeatureData>, IProductFeaturesRepository
    {
        public ProductFeaturesRepository(ProductDbContext c = null) : base(c, c?.ProductFeatures) { }

        protected internal override ProductFeature toDomainObject(ProductFeatureData d) => new ProductFeature(d);
    }
}
