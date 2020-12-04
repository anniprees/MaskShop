using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Common;

namespace MaskShop.Data.Orders
{
    public abstract class PartyProductsData : DefinedEntityData
    {
        public string PartyId { get; set; }
    }
}
