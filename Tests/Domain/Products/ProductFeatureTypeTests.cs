using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Domain.Products
{
    [TestClass]
    public class ProductFeatureTypeTests : SealedClassTests<ProductFeatureType, DefinedEntity<ProductFeatureTypeData>>
    {
        [TestMethod] public void NumericCodeTest() => IsReadOnlyProperty(obj.Data.NumericCode);

        [TestMethod] public void IsMandatoryTest() => IsReadOnlyProperty(obj, nameof(obj.IsMandatory), obj.Data.IsMandatory);
    }
}