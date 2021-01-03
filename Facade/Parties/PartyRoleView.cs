using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Domain.Common;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Parties
{
    public sealed class PartyRoleView: UniqueEntityView
    {
        [Required]
        [DisplayName("Role")] public string Role { get; set; }
    }
}
