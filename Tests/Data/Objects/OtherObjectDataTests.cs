using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class OtherObjectDataTests : SealedClassTests<OtherObjectData, ObjectData>
    {
        [TestMethod]
        public void ObjectContentTest()
            => IsProperty(() => obj.ObjectContent, x => obj.ObjectContent = x);
    }
}
