using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Data.Parties;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Parties
{
    public sealed class PartyView: NamedView
    {
        //[Required]
        //[DisplayName("Party Name Id")] public string PartyNameId { get; set; }

        [Required]
        [DisplayName("Party Role Id")] public string PartyRoleId { get; set; }

        [Required]
        [DisplayName("Contact Mechanism Id")] public string ContactMechanismId { get; set; }

        [Required]
        [DisplayName("Party Type")] public PartyType PartyType { get; set; }
    }
}


