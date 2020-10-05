using Data.Common;

namespace MaskShop.Data.Parties
{
    public sealed class ContactMechanismData : UniqueEntityData
    {
        public string CountryId { get; set; }

        public string NationalDirectDialingPrefix { get; set; }

        public string Address { get; set; }

        public string CityOrAreaCode { get; set; }

        public string RegionOrStateOrCountryCode { get; set; }

        public string ZipOrPostCodeOrExtension { get; set; }

        public ContactMechanismTypeData ContactMechanismType { get; set; }
    }
}
