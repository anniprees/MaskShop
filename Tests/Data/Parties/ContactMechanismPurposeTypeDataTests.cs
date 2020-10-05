using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismPurposeTypeDataTests : SealedTests <ContactMechanismPurposeTypeData, UniqueEntityData>
    {
        [TestMethod] public void DescriptionTest() => isNullableProperty<string>();
    }
}
