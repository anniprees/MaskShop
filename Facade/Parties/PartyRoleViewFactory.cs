using MaskShop.Aids.Methods;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;

namespace MaskShop.Facade.Parties
{
    public static class PartyRoleViewFactory
    {
        public static PartyRole Create(PartyRoleView v)
        {
            var d = new PartyRoleData();
            Copy.Members(v, d);
            return new PartyRole(d);
        }

        public static PartyRoleView Create(PartyRole o)
        {
            var v = new PartyRoleView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}

