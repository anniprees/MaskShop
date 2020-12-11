using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Parties
{
    public sealed class PartyNameView: PartyAttributeView
    {
        [Required]
        [DisplayName("Name")] public string Name { get; set; }

        [DisplayName("Given Name")] public string GivenName { get; set; }

        [DisplayName("Middle Name")] public string MiddleName { get; set; }

        [DisplayName("Preferred Name")] public string PreferredName { get; set; }
    }
}



