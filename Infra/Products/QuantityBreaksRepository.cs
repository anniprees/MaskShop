﻿using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class QuantityBreaksRepository : UniqueEntityRepository<QuantityBreak, QuantityBreakData>, IQuantityBreaksRepository
    {
        public QuantityBreaksRepository(ProductDbContext c = null) : base(c, c?.QuantityBreaks) { }

        protected internal override QuantityBreak toDomainObject(QuantityBreakData d) => new QuantityBreak(d);
    }
}