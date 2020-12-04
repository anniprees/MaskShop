using MaskShop.Data.Common;

namespace MaskShop.Data.Parties
{
    public sealed class ContactMechanismData : UniqueEntityData
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipOrPostCode { get; set; }
        public string ElectronicMail { get; set; }
    }
}
