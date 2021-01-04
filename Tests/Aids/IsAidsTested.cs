using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class IsAidsTested : BaseAssemblyTests
    {
        protected override string Assembly => "MaskShop.Aids";
        protected override string NameSpace(string name) { return $"{Assembly}.{name}"; }
    }
}
