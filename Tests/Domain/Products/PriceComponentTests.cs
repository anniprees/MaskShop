using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class PriceComponentTests : SealedClassTests<PriceComponent, UniqueEntity<PriceComponentData>>
    {
        protected override PriceComponent CreateObject() => new PriceComponent(GetRandom.Object<PriceComponentData>());

        [TestMethod]
        public void PriceTest() => IsReadOnlyProperty(obj.Data.Price);

        [TestMethod]
        public void PercentTest() => IsReadOnlyProperty(obj.Data.DiscountComponent);

        [TestMethod]
        public void CommentTest() => IsReadOnlyProperty(obj.Data.Comment);

        [TestMethod]
        public void ProductIdTest() => IsReadOnlyProperty(obj.Data.ProductId);

        [TestMethod]
        public void ConsumerRoleTypeIdTest() => IsReadOnlyProperty(obj.Data.ConsumerRoleTypeId);

        //[TestMethod]
        //public void ProductTest() =>
        //    GetFromRepository<ProductData, Product, IProductsRepository>(obj.ProductId, () => obj.Product.Data, d => new Product(d));

    }
}