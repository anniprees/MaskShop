using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class InventoryItemsRepository : UniqueEntityRepository<InventoryItem, InventoryItemData>, IInventoryItemsRepository
    {
        public InventoryItemsRepository(ShopDbContext c = null) : base(c, c?.InventoryItems) { }

        protected internal override InventoryItem ToDomainObject(InventoryItemData d) => new InventoryItem(d);
    }
}