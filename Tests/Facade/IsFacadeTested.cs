using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        protected override string assembly => "MaskShop.Facade";

        protected override string nameSpace(string name) { return $"{assembly}.{name}"; }
    }
}
