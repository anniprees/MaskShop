﻿using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
   public class OrderValueViewFactory
    {
       public static OrderValueView Create(OrderValue o)
       {
           var v = new OrderValueView();
           Copy.Members(o.Data, v);

           return v;
       }
       public static OrderValue Create(OrderValueView v)
       {
           var d = new OrderValueData();
           Copy.Members(v, d);

           return new OrderValue(d);
       }
   }

}