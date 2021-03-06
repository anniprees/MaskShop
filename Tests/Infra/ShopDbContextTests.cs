﻿using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using MaskShop.Infra;
using MaskShop.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra
{
    public abstract class
        ShopDbContextTests<TRepository, TDomain, TData> : SealedClassTests<TRepository,
            PaginatedRepository<TDomain, TData>>
        where TRepository : PaginatedRepository<TDomain, TData>
        where TData : PeriodData, new()
        where TDomain : IEntity<TData>
    {

        protected ShopDbContext db;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            //var options = new DbContextOptionsBuilder<ShopDbContext>().UseInMemoryDatabase("TestDb").Options;
            var options = new DbContextOptionsBuilder<ShopDbContext>().Options;
            db = new ShopDbContext(options);
        }

        //[TestMethod]
        //public void CanSetContextAndSetTest()
        //{
        //    obj = GetObject(db);
        //    Assert.AreSame(db, obj.db);
        //    Assert.AreSame(GetSet(db), obj.dbSet);
        //}

        protected abstract TRepository GetObject(ShopDbContext db);

        protected abstract DbSet<TData> GetSet(ShopDbContext db);

        //[TestMethod]
        //public virtual void ToDomainObjectTest()
        //{
        //    var d = (TData)GetRandom.Object(typeof(TData));
        //    var o = obj.ToDomainObject(d);
        //    ArePropertiesEqual(d, o.Data);
        //}

    }
}