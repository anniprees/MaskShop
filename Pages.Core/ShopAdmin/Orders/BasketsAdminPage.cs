﻿using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Domain.Orders;
using MaskShop.PagesCore.Shop.Orders;

namespace MaskShop.PagesCore.ShopAdmin.Orders
{
    public class BasketsAdminPage : BasketsPage<BasketsAdminPage>
    {
        public BasketsAdminPage(IBasketsRepository r) : base(r) { }

        protected internal override Uri pageUrl() => new Uri("/Shop/Baskets", UriKind.Relative);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Id);
            createColumn(x => Item.PartyId);
            createColumn(x => Item.PartyName);
            createColumn(x => Item.PartyAddress);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.ValidFrom);
        }
    }
}
