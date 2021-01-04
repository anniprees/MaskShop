﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Aids.Constants;
using MaskShop.Data.Common;
using MaskShop.Data.Products;
using MaskShop.Domain.Common;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.Common;
using MaskShop.PagesCore.Common.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaskShop.PagesCore.Shop.Products
{
    public abstract class ProductsPage<TPage> : 
        ViewPage<TPage, IProductsRepository, Product, ProductView, ProductData> 
        where TPage : PageModel

    {
        public IEnumerable<SelectListItem> Categories { get; }
        public IBasketsRepository Baskets { get; }
        public IBasketItemsRepository BasketItems { get; }

        protected ProductsPage(IProductsRepository r, IProductCategoriesRepository c, IBasketsRepository b, IBasketItemsRepository bi) :
            base(r, "Products")
        {
            Categories = newItemsList<ProductCategory, ProductCategoryData>(c);
            Baskets = b;
            BasketItems = bi;
        }

        public string CategoryName(string id) => itemName(Categories, id);

        protected internal override Product toObject(ProductView v) => new ProductViewFactory().Create(v);
        protected internal override ProductView toView(Product o) => new ProductViewFactory().Create(o);

        protected override void createTableColumns()
        {
            createColumn(x => Item.Name);
            createColumn(x => Item.ProductCategoryId);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.Price);
        }

        public virtual async Task<IActionResult> OnGetSelectAsync(string id, string sortOrder, string searchString,
            int pageIndex, string fixedFilter, string fixedValue)
        {
            Product p = await db.Get(id);
            Basket b = await Baskets.GetLatestForUser(User.Identity.Name);
            BasketItem i = await BasketItems.Add(b, p);

            var url = new Uri($"{BasketItemsPage}/Edit?handler=Edit" +
                              $"&id={i.Id}" +
                              $"&fixedFilter={nameof(i.BasketId)}" +
                              $"&fixedValue={b.Id}", UriKind.Relative);

            return Redirect(url.ToString());
        }
        protected abstract string BasketItemsPage { get; }
    }
}