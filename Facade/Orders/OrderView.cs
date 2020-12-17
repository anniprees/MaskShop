using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MaskShop.Facade.Orders
{
    public sealed class OrderView : PartyProductsView
    {
        [DisplayName("Name")]
        public string PartyNameId { get; set; }

        [DisplayName("Address")]
        public string ContactMechanismId { get; set; }

        [DisplayName("Total price")]
        public decimal TotalPrice { get; set; }
    }
}
