using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class OrderValueViewFactory
    {
            public static OrderValue Create(OrderValueView v)
            {
                var d = new OrderValueData();
                Copy.Members(v, d);
                return new OrderValue(d);
            }

            public static OrderValueView Create(OrderValue o)
            {
                var v = new OrderValueView();
                Copy.Members(o?.Data, v);
                return v;
            }
    }
}
