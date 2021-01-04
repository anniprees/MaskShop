using System.Threading.Tasks;
using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductTests : SealedClassTests<Product, NamedEntity<ProductData>>
    {
        protected override Product CreateObject() => new Product(GetRandom.Object<ProductData>());

        [TestMethod]
        public void ProductCategoryIdTest() => IsReadOnlyProperty(obj, nameof(obj.ProductCategoryId), obj.Data.ProductCategoryId);

        [TestMethod]
        public void PriceComponentIdTest() => IsReadOnlyProperty(obj, nameof(obj.PriceComponentId),obj.Data.PriceComponentId);

        [TestMethod]
        public void PriceTest() => IsReadOnlyProperty(obj.Data.Price);

        [TestMethod]
        public void PictureUriTest() => IsReadOnlyProperty(obj.Data.PictureUri);

        [TestMethod]
        public void PictureTest() => IsReadOnlyProperty(obj.Data.Picture);

        [TestMethod]
        public async Task ProductCategoryTest()
        {
            var p = GetRandom.Object<ProductCategoryData>();
            p.Id = obj.ProductCategoryId;
            await GetRepository.Instance<IProductCategoriesRepository>().Add(new ProductCategory(p));
            TestArePropertiesEqual(p, obj.ProductCategory.Data);
        }
            
            //=>
            //GetFromRepository<ProductCategoryData, ProductCategory, IProductCategoriesRepository>(
            //    obj.ProductCategoryId, () => obj.ProductCategory.Data, d => new ProductCategory(d));

        [TestMethod]
        public void PriceComponentTest() =>
            GetFromRepository<PriceComponentData, PriceComponent, IPriceComponentsRepository>(
                obj.PriceComponentId, () => obj.PriceComponent.Data, d => new PriceComponent(d));

    }
}