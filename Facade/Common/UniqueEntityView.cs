using System.ComponentModel.DataAnnotations;

namespace MaskShop.Facade.Common
{
    public abstract class UniqueEntityView : PeriodView
    {
        [Required]
        public string Id { get; set; }

        public override string GetId() => Id;

    }

}