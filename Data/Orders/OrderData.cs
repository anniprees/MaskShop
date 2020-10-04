using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Orders
{
    public sealed class OrderData : UniqueEntityData
    {
        public string ContactMechanismId { get; set; }

        public string PartyRoleId { get; set; }
    }
}
