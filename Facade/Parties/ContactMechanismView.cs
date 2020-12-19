using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Parties
{
    public sealed class ContactMechanismView: UniqueEntityView
    {
        [Required]
        [DisplayName("Country")] public string Country { get; set; }

        [Required]
        [DisplayName("State")] public string State { get; set; }

        [Required]
        [DisplayName("City")] public string City { get; set; }

        [Required]
        [DisplayName("Street")] public string Street { get; set; }

        //[Required]
        //[DisplayName("Address")] public string Address { get; set; }

        [Required]
        [DisplayName("Zipcode")] public string ZipCode { get; set; }

        [Required]
        [DisplayName("E-mail")] public string ElectronicMail { get; set; }
    }
}


