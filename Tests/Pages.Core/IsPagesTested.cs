using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Pages.Core
{
    [TestClass]
    public class IsPagesCoreTested : AssemblyTests
    {
        protected override string Assembly => "MaskShop.Pages.Core";

        protected override string NameSpace(string name) { return $"{Assembly}.{name}"; }
    }
}
