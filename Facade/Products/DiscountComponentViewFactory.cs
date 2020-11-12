using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
   public static class DiscountComponentViewFactory
    { 
       public static DiscountComponent Create(DiscountComponentView v)
       {
            var d = new DiscountComponentData();
            Copy.Members(v, d);
            return new DiscountComponent(d);
       }

       public static DiscountComponentView Create(DiscountComponent o)
       {
           var v = new DiscountComponentView();
           Copy.Members(o?.Data, v);
           return v;
       }
    }
}
