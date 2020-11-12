using MaskShop.Facade.Common;
using MaskShop.Facade.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade.Products
{
    public class ProductFeatureApplicabilityViewTests : AbstractClassTests<ProductFeatureApplicabilityView, PeriodView>
    {

        [TestMethod] public void UnitIdTest() => IsNullableProperty<string>("Product Id");

        [TestMethod] public void CurrencyIdTest() => IsNullableProperty<string>("Product feature Id");

        
    }
}

