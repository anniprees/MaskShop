using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Basket> GetLatestForUser(string name)
        {
            var l = await dbSet
                .Where(x => x.PartyId == name && x.ValidTo == null)
                .OrderByDescending(x => x.ValidFrom)
                .ToListAsync();
            if (l.Count > 0) return ToDomainObject(l[0]);
            var d = new BasketData { PartyId = name, ValidFrom = DateTime.Now};
            var o = new Basket(d);
            await Add(o);
            return o;
        }

        public async Task Close(Basket b, string basketId)
        {
            var d = b?.Data;
            basketId = b.Id;
            if (d == null) return;
            d.ValidTo = DateTime.Now;
            await Delete(basketId);
            //await Update(new Basket(d));
        }
    }
}
