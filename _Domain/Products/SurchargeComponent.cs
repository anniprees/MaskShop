using MaskShop.Data.Products;

namespace MaskShop.Domain.Products
{
    public sealed class SurchargeComponent: PriceComponent<SurchargeComponentData>
    {
        public SurchargeComponent() : this(null) { }

        public SurchargeComponent(SurchargeComponentData d) : base(d) { }
    }
}
