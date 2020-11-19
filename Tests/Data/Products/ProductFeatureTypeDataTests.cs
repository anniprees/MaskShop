using MaskShop.Data.Common;
using MaskShop.Data.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Products
{
    [TestClass]
    public class ProductFeatureTypeDataClassTests : SealedClassTests<ProductFeatureTypeData, DefinedEntityData> 
    {
        [TestMethod] public void IsMandatoryTest() => IsProperty(() => obj.IsMandatory, x => obj.IsMandatory = x);
        [TestMethod] public void NumericCodeTest() => IsProperty<int>(() => obj.NumericCode, x => obj.NumericCode = x);
    }
}
