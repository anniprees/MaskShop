using MaskShop.Data.Products;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Products
{
    public sealed class InventoryItem: UniqueEntity<InventoryItemData>
    {
        public InventoryItem() : this(null) { }
        public InventoryItem(InventoryItemData d) : base(d) { }

        public int QuantityOnHand => Data?.QuantityOnHand ?? UnspecifiedInteger;
        public string ProductId => Data?.ProductId ?? Unspecified;
        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);
    }
}