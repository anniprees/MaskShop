using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Orders;
using MaskShop.Domain.Common;
using MaskShop.Domain.Products;

namespace MaskShop.Domain.Orders
{
    public abstract class ItemProduct<TData> : Entity<TData>
    where TData : ItemProductData,  new()
    {
        protected ItemProduct(TData d) : base(d) { }

        public string ProductId => Data?.ProductId ?? Unspecified;

        public Product Product => new GetFrom<IProductsRepository, Product>().ById(ProductId);

        public int Quantity => Data?.Quantity ?? UnspecifiedInteger;

        public decimal TotalPrice => Product?.Price ?? 0M * Quantity;
    }
}
