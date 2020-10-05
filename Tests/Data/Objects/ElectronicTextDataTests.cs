using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class ElectronicTextDataTests : SealedClassTests<ElectronicTextData, ObjectData>
    {
        [TestMethod]
        public void ElectronicTextTest()
            => IsProperty(() => obj.ElectronicText, x => obj.ElectronicText = x);
    }
}
