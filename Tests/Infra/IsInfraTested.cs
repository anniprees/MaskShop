using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        protected override string Assembly => "MaskShop.Infra";

        protected override string NameSpace(string name) { return $"{Assembly}.{name}"; }
    }
}
