
using System;
using System.IO;
using MaskShop.Aids.Methods;
using MaskShop.Data.Products;
using MaskShop.Domain.Products;

namespace MaskShop.Facade.Products
{
    public static class ProductViewFactory
    {
        public static Product Create(ProductView v)
        {
            var d = new ProductData();
            d.PictureUri = v?.PictureFile?.FileName;
            var stream = new MemoryStream();
            v?.PictureFile?.CopyTo(stream);
            if (stream.Length < 2097152)
                d.Picture = stream.ToArray();
            Copy.Members(v, d);
            return new Product(d);
        }

        public static ProductView Create(Product o)
        {
            var v = new ProductView();
            var s = Convert.ToBase64String(
                o?.Picture ?? Array.Empty<byte>(), 0,
                o?.Picture?.Length ?? 0);
            v.PictureUri = "data:image/jpg;base64," + s;
            Copy.Members(o?.Data, v);
            return v;
        }
    }
}

