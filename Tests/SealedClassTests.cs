using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public abstract class SealedClassTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class
    {
        [TestMethod]
        public void IsSealed()
        {
            Assert.IsTrue(type.IsSealed);
        }
    }
}
