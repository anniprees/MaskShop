using MaskShop.Aids.Methods;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;

namespace MaskShop.Facade.Parties
{
    public static class PartyViewFactory
    {
        public static Party Create(PartyView v)
        {
            var d = new PartyData();
            Copy.Members(v, d);
            return new Party(d);
        }

        public static PartyView Create(Party o)
        {
            var v = new PartyView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}
