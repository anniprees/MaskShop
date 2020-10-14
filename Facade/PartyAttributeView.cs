using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MaskShop.Facade
{
    public abstract class PartyAttributeView : UniqueEntityView
    {
        [DisplayName("Belongs to")]
        public string PartyId { get; set; }
    }
}
