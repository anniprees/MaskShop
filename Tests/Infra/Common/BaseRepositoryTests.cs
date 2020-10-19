using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra.Common
{
    [TestClass]
    public class BaseRepositoryTests
    : AbstractClassTests<BaseRepository<Product, ProductData>, object>
    {
        //private class TestClass : BaseRepository<Product, ProductData>
        //{
        //    public TestClass(DbContext c, DbSet<ProductData> s) : base(c, s) { }
        //    protected override Product ToDomainObject(ProductData d) => ProductFactory.Create(d);
        //}
    }
}
