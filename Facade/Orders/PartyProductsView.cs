using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Orders
{
    public abstract class PartyProductsView : DefinedView
    {
        [DisplayName("Buyer")] 
        public string PartyId { get; set; }
    }
}
