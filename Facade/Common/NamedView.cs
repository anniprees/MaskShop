using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Common
{
    public abstract class NamedView : UniqueEntityView
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can be no longer than 30 characters")]
        public string Name { get; set; }
    }
}