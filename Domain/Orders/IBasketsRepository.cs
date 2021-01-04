using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Orders
{
    public interface IBasketsRepository : IRepository<Basket>
    {
        Task<Basket> GetLatestForUser(string name);
        Task Close(Basket b, string basketId);
    }
}
