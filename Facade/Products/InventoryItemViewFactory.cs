using MaskShop.Aids;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class InventoryItemViewFactory
    {
        public static InventoryItem Create(InventoryItemView v)
        {
            var d = new InventoryItemData();
            Copy.Members(v, d);
            return new InventoryItem(d);
        }

        public static InventoryItemView Create(InventoryItem o)
        {
            var v = new InventoryItemView();
            Copy.Members(o?.Data, v);
            v.FeatureCombo = o?.ProductFeatureApplicability.FeatureCombo;
            return v;
        }
    }
}