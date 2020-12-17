using MaskShop.Data.Common;

namespace MaskShop.Data.Parties
{
    public sealed class ContactMechanismData : UniqueEntityData
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ElectronicMail { get; set; }
    }
}
