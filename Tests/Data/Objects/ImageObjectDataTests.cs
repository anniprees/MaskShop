using MaskShop.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data.Objects
{
    [TestClass]
    public class ImageObjectDataTests : SealedClassTests<ImageObjectData, ObjectData>
    {
        [TestMethod]
        public void ImageTest()
            => IsProperty(() => obj.Image, x => obj.Image = x);
    }
}
