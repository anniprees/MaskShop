using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests
{
    public class AssemblyTests : BaseAssemblyTests
    {
        [TestMethod] public void IsCommonTested() => IsAllTested(Assembly, NameSpace("Common"));
        [TestMethod] public void IsOrdersTested() => IsAllTested(Assembly, NameSpace("Orders"));
        [TestMethod] public void IsPartiesTested() => IsAllTested(Assembly, NameSpace("Parties"));
        [TestMethod] public void IsProductsTested() => IsAllTested(Assembly, NameSpace("Products"));
    }
}
