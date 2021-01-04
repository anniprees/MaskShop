using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Common
{
    [TestClass]
    public class GetFromTests : SealedClassTests<GetFrom<IProductsRepository, Product>,object>
    {
        protected IProductsRepository repository;
        protected string id;
        protected string ProductCategoryId;

        protected ProductData data;
        protected Product item;
        private Product CreateItem() => new Product(data);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            repository = GetRepository.Instance<IProductsRepository>();
            data = GetRandom.Object<ProductData>();
            ProductCategoryId = GetRandom.String();
            id = ProductCategoryId;
            item = CreateItem();
        }
        protected virtual IReadOnlyList<Product> getList() => obj.ListBy("ProductCategoryId", ProductCategoryId);

        [TestMethod] public void RepositoryTest() => Assert.AreSame(repository, obj.Repository);

        [TestMethod]
        public void ByIdTest()
        {
            var t = obj.ById(id);
            Assert.IsNotNull(t);
            Assert.IsInstanceOfType(t, typeof(Product));
            Assert.IsTrue(t.IsUnspecified);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            repository.Add(item).GetAwaiter();
            TestArePropertiesEqual(data, obj.ById(id).Data);
        }

        [TestMethod]
        protected void ListTest()
        {
            var t = getList();
            Assert.IsNotNull(t);
            Assert.IsInstanceOfType(t, typeof(IReadOnlyList<Product>));
            Assert.AreEqual(0, t.Count);
        }

        [TestMethod]
        protected void ContentTest()
        {
            ListTest();
            var count = GetRandom.UInt8(10, 30);

            for (var i = 0; i < count; i++)
            {
                data = GetRandom.Object<ProductData>();
                if (i % 4 == 0) UpdateData(i);
                repository.Add(CreateItem()).GetAwaiter();
            }
            var c = (int)Math.Ceiling(count / 4.0);
            var t = getList();
            Assert.AreEqual(c, t.Count);
        }
        
        [TestMethod]
        private void UpdateData(int idx)
        {
            if (idx % 4 == 0) data.ProductCategoryId = ProductCategoryId;
        }

        [TestMethod] public void ListByTest() => ListTest();

        [TestMethod] public void ListContextTest() => ContentTest();
    }
}
