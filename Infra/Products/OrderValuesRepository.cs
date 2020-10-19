﻿using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class OrderValuesRepository : UniqueEntityRepository<OrderValue, OrderValueData>, IOrderValuesRepository
    {
    public OrderValuesRepository(ProductDbContext c = null) : base(c, c?.OrderValues) { }

    protected internal override OrderValue toDomainObject(OrderValueData d) => new OrderValue(d);
    }
}