using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        protected override string Assembly => "MaskShop.Data";
        protected override string NameSpace(string name) { return $"{Assembly}.{name}"; }
    }
}
