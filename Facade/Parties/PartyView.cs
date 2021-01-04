using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Data.Parties;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Parties
{
    public sealed class PartyView: NamedView
    {
        [Required]
        [DisplayName("Party Role")] public string PartyRoleId { get; set; }

        [Required]
        [DisplayName("Contact Mechanism")] public string ContactMechanismId { get; set; }

        [Required]
        [DisplayName("Party Type")] public PartyType PartyType { get; set; }
    }
}


