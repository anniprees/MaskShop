using MaskShop.Aids.Methods;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;

namespace MaskShop.Facade.Parties
{
    public static class PartyNameViewFactory
    {
        public static PartyName Create(PartyNameView v)
        {
            var d = new PartyNameData();
            Copy.Members(v, d);
            return new PartyName(d);
        }

        public static PartyNameView Create(PartyName o)
        {
            var v = new PartyNameView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}

