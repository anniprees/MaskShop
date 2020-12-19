using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Parties
{
    public sealed class PartyNameView: PartyAttributeView
    {
        [Required]
        [DisplayName("First Name")] public string FirstName { get; set; }

        [DisplayName("Middle Name")] public string MiddleName { get; set; }

        [Required]
        [DisplayName("Last Name")] public string LastName { get; set; }
    }
}




