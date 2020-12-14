using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Parties
{
    public abstract class PartyAttributeView: UniqueEntityView
    {
        [Required]
        [DisplayName("Party Id")] public string PartyId { get; set; }
    }
}


