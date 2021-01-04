using MaskShop.Aids;
using MaskShop.Data.Parties;
using MaskShop.Domain.Parties;

namespace MaskShop.Facade.Parties
{
    public static class ContactMechanismViewFactory
    {
        public static ContactMechanism Create(ContactMechanismView v)
        {
            var d = new ContactMechanismData();
            Copy.Members(v, d);
            return new ContactMechanism(d);
        }

        public static ContactMechanismView Create(ContactMechanism o)
        {
            var v = new ContactMechanismView();
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}

