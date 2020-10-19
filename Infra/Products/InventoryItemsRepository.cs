﻿using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Infra.Common;

namespace MaskShop.Infra.Products
{
    public sealed class InventoryItemsRepository : UniqueEntityRepository<InventoryItem, InventoryItemData>, IInventoryItemsRepository
    {
        public InventoryItemsRepository(ProductDbContext c = null) : base(c, c?.InventoryItems) { }

        protected internal override InventoryItem toDomainObject(InventoryItemData d) => new InventoryItem(d);
    }
}