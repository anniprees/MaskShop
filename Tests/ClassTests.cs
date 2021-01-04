using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public abstract class ClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass> where TClass : class
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            obj = CreateObject();
            Type = obj.GetType();
        }
        protected virtual TClass CreateObject() => GetRandom.Object<TClass>();
    }
}