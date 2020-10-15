using System.ComponentModel;

namespace MaskShop.Facade.Common
{
    public abstract class EntityTypeView : DefinedView
    {
        [DisplayName("Base Type")]
        public string BaseTypeId { get; set; }
    }

}