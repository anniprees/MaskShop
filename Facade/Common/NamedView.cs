using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Common
{
    public abstract class NamedView : UniqueEntityView
    {
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

    }

}