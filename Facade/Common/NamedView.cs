using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Common
{
    public abstract class NamedView : UniqueEntityView
    {
        [Required]
        public string Name { get; set; }
    }
}