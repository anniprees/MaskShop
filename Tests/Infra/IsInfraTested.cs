using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        protected override string assembly => "MaskShop.Infra";

        protected override string nameSpace(string name) { return $"{assembly}.{name}"; }
    }
}
