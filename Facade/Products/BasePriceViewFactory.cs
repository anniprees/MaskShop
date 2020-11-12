using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class BasePriceViewFactory
    { 
        public static BasePrice Create(BasePriceView v)
        {
            var d = new BasePriceData();
            Copy.Members(v, d);
            return new BasePrice(d);
        }

         public static BasePriceView Create(BasePrice o)
        {
            var v = new BasePriceView();
            Copy.Members(o?.Data, v); 
            return v;
        }
    }
}
