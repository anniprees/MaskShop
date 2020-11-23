using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Common;
using MaskShop.Domain.Common;
using MaskShop.Infra.Common;
using MaskShop.Infra.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Products
{
    public abstract class
        ProductRepositoryTests<TRepository, TDomain, TData> : SealedClassTests<TRepository,
            PaginatedRepository<TDomain, TData>>
        where TRepository : PaginatedRepository<TDomain, TData>
        where TData : PeriodData, new()
        where TDomain : IEntity<TData>
    {

        protected ProductDbContext db;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            //var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase("TestDb").Options;
            var options = new DbContextOptionsBuilder<ProductDbContext>().Options;
            db = new ProductDbContext(options);
        }

        //[TestMethod]
        //public void CanSetContextAndSetTest()
        //{
        //    obj = GetObject(db);
        //    Assert.AreSame(db, obj.db);
        //    Assert.AreSame(GetSet(db), obj.dbSet);
        //}

        protected abstract TRepository GetObject(ProductDbContext db);

        protected abstract DbSet<TData> GetSet(ProductDbContext db);

        //[TestMethod]
        //public virtual void ToDomainObjectTest()
        //{
        //    var d = (TData)GetRandom.Object(typeof(TData));
        //    var o = obj.ToDomainObject(d);
        //    ArePropertiesEqual(d, o.Data);
        //}

    }
}