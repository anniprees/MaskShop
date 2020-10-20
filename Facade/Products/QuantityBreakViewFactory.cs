using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class QuantityBreakViewFactory
    { 
        public static QuantityBreakView Create(QuantityBreak o)
            {
                var v = new QuantityBreakView();
                Copy.Members(o.Data, v);

                return v;
            }

            public static QuantityBreak Create(QuantityBreakView v)
            {
                var d = new QuantityBreakData();
                Copy.Members(v, d);

                return new QuantityBreak(d);
            }
        }
    }