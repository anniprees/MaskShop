using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Parties
{
    public sealed class PartyRoleView: PartyAttributeView
    {
        [Required]
        [DisplayName("Role")] public string Role { get; set; }
    }
}
