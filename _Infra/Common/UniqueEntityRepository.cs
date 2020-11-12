using System.Threading.Tasks;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Common
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TDomain : IEntity<TData>
        where TData : UniqueEntityData, new()
    {

        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected override async Task<TData> GetData(string id)
            => await dbSet.FirstOrDefaultAsync(m => m.Id == id);

        protected override TData GetDataById(TData d) => dbSet.Find(d.Id);

    }

}
