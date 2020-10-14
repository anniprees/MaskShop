using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MaskShop.Facade
{
    public abstract class EntityTypeView : DefinedView
    {
        [DisplayName("Base Type")]
        public string BaseTypeId { get; set; }
    }

}