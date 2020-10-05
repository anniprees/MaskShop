using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;
using MaskShop.Data.Parties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Parties
{
    [TestClass]
    public class ContactMechanismPurposeTypeDataClassTests : SealedClassTests <ContactMechanismPurposeTypeData, UniqueEntityData>
    {
        [TestMethod] public void DescriptionTest() => IsNullableProperty<string>(() => obj.Description, x => obj.Description = x);
    }
}
