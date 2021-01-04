using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace MaskShop.Infra.Common
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
         where TDomain : IEntity<TData>
         where TData : PeriodData, new()
    {

        protected internal DbContext db;
        public DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }

        public virtual async Task<List<TDomain>> Get()
        {
            var query = createSqlQuery();
            var set = await RunSqlQueryAsync(query);

            return ToDomainObjectsList(set);
        }

        public async Task<TDomain> Get(string id)
        {
            if (id is null) return ToDomainObject(new TData());

            var d = await GetData(id);

            var obj = ToDomainObject(d);

            return obj;
        }

        public async Task Delete(string id)
        {
            if (id is null) return;

            var v = await GetData(id);

            if (v is null) return;
            dbSet.Remove(v);
            await db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            var d = GetData(obj);

            if (d is null) return;

            if (IsInDatabase(d)) await Update(obj);
            else await dbSet.AddAsync(d);

            await db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            var d = GetData(obj);
            d = CopyData(d);
            db.Attach(d).State = EntityState.Modified;

            //TODO BaseRepository db.SaveChangesAsync
            //try {
            await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException) {
            //    //if (!MeasureViewExists(MeasureView.Id))
            //    //{
            //    //    return NotFound();
            //    //}
            //    //else
            //    //{
            //    throw;
            //    //}
            //}
        }

        public object GetById(string id) => Get(id).GetAwaiter().GetResult();

        protected internal virtual IQueryable<TData> createSqlQuery()
        {
            var query = from s in dbSet select s;

            return query;
        }

        protected internal abstract TDomain ToDomainObject(TData periodData);

        protected abstract Task<TData> GetData(string id);

        protected TData GetData(TDomain obj) => obj?.Data;

        protected abstract TData GetDataById(TData d);

        protected bool IsInDatabase(TData d) => GetDataById(d) != null;

        internal async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query)
            => await query.AsNoTracking().ToListAsync();

        internal List<TDomain> ToDomainObjectsList(List<TData> set)
            => set.Select(ToDomainObject).ToList();

        private TData CopyData(TData d)
        {
            var x = GetDataById(d);

            if (x is null) return d;
            Copy.Members(d, x);

            return x;
        }

    }

}