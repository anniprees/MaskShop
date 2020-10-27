using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass>
    {

        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(type.IsAbstract);

        }

        protected void IsAbstractMethod(string name)
        {
            var i = type.GetMethod(name);
            Assert.IsNotNull(i);
            Assert.IsTrue(i.IsAbstract);
        }

        protected void IsAbstractProperty(string name)
        {
            var i = type.GetProperty(name);
            Assert.IsNotNull(i);
            if (i.CanRead) Assert.IsTrue(IsAbstract(i.GetGetMethod()));
            if (i.CanWrite) Assert.IsTrue(IsAbstract(i.GetSetMethod()));
        }
        private static bool IsAbstract(MethodInfo i) => i?.IsAbstract ?? false;

    }
}
