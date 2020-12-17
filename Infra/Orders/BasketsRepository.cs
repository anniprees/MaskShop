using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Orders;
using MaskShop.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Orders
{
    public sealed class BasketsRepository : UniqueEntityRepository<Basket, BasketData>, IBasketsRepository
    {
        public BasketsRepository(ShopDbContext c = null) : base(c, c?.Baskets) { }

        protected internal override Basket ToDomainObject(BasketData d) 
            => new Basket(d);
    }
}
