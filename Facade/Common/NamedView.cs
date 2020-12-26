using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Common
{
    public abstract class NamedView : UniqueEntityView
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(15, ErrorMessage = "Name can be no longer than 15 characters")]
        public string Name { get; set; }
    }
}