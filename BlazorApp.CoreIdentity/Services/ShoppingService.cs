using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.PagesCore.ShopClient.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.CoreIdentity.Services
{
    public class ShoppingService
    {
        private readonly IProductsRepository _context;

        public ShoppingService(IProductsRepository context)
        {
            _context = context;
        }

        public async Task<List<ProductView>> GetProducts()
        {
            var result = await _context.Get();
            var aa = new List<ProductView>();

            result.ForEach(x => aa.Add(new ProductViewFactory().Create(x)));

            return aa.ToList();
        }

        public async Task<ProductView> GetProductById(string id)
        {
            var product = await _context.Get(id);

            if (product == null)
            {
                return null;
            }
            return new ProductViewFactory().Create(product);
        }
    }

}