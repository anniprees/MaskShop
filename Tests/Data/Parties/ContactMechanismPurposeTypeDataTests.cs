using MaskShop.Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismPurposeTypeDataTests : SealedClassTests <ContactMechanismPurposeTypeData, UniqueEntityData>
    {
        [TestMethod] public void DescriptionTest() => IsNullableProperty<string>();
    }
}
