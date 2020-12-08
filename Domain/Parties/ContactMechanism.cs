using MaskShop.Data.Parties;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Parties
{
    public sealed class ContactMechanism: UniqueEntity<ContactMechanismData>
    {
       public ContactMechanism(ContactMechanismData d) : base(d) { }

        public string Country => Data?.Country ?? Unspecified;
        public string State => Data?.State ?? Unspecified;
        public string City => Data?.City ?? Unspecified;
        public string Address => Data?.Address ?? Unspecified;
        public string ZipOrPostCode => Data?.ZipOrPostCode ?? Unspecified;
        public string ElectronicMail => Data?.ElectronicMail ?? Unspecified;
    }
}

