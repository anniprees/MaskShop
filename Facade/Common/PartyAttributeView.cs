using System.ComponentModel;

namespace MaskShop.Facade.Common
{
    public abstract class PartyAttributeView : UniqueEntityView
    {
        [DisplayName("Belongs to")]
        public string PartyId { get; set; }
    }
}
