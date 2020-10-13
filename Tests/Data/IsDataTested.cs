using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        protected override string assembly => "MaskShop.Data";
        protected override string nameSpace(string name) { return $"{assembly}.{name}"; }
    }
}
