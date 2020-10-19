using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        protected override string Assembly => "MaskShop.Facade";

        protected override string NameSpace(string name) { return $"{Assembly}.{name}"; }
    }
}
