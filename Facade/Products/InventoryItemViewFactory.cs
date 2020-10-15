﻿using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public class InventoryItemViewFactory
    {
        public static InventoryItemView Create(InventoryItem o)
        {
            var v = new InventoryItemView();
            Copy.Members(o.Data, v);

            return v;
        }
        public static InventoryItem Create(InventoryItemView v)
        {
            var d = new InventoryItemData();
            Copy.Members(v, d);

            return new InventoryItem(d);
        }
    }

}