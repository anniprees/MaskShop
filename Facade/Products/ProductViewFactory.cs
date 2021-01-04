
using System;
using System.IO;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;
using MaskShop.Facade.Common;

namespace MaskShop.Facade.Products
{
    public sealed class ProductViewFactory : AbstractViewFactory<ProductData, Product, ProductView>
    {
        protected internal override Product ToObject(ProductData d) => new Product(d);
        protected internal override void CopyMembers(ProductView v, ProductData d)
        {
            base.CopyMembers(v, d);
            d.PictureUri = v?.PictureFile?.FileName;
            var stream = new MemoryStream();
            v?.PictureFile?.CopyTo(stream);
            if (stream.Length < 2097152)
                d.Picture = stream.ToArray();
        }
        protected internal override void CopyMembers(ProductData d, ProductView v)
        {
            base.CopyMembers(d, v);
            var s = Convert.ToBase64String(
                d?.Picture ?? Array.Empty<byte>(), 0,
                d?.Picture?.Length ?? 0);
            v.PictureUri = "data:image/jpg;base64," + s;
        }
    }
}

