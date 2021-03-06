﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MaskShop.Facade.Orders
{
    public sealed class BasketView : PartyProductsView
    {
        [DisplayName("Name")]
        public string PartyName { get; set; }

        [DisplayName("Address")]
        public string PartyAddress { get; set; }

        [DisplayName("Total price")]
        public decimal TotalPrice { get; set; }
    }
}
