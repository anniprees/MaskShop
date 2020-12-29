using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Orders;
using MaskShop.Domain.Products;
using MaskShop.Facade.Orders;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemsController : ControllerBase
    {
        private readonly IBasketItemsRepository _bir;
        private readonly IProductsRepository _pr;
        private readonly IBasketsRepository _br;

        public  BasketItemsController(IBasketItemsRepository bir, IProductsRepository pr, IBasketsRepository br)
        {
            _bir = bir;
            _pr = pr;
            _br = br;
        }

        [HttpGet]
        public async Task<ActionResult<List<BasketItemView>>> GetBasketItems(string name)
        {
            var result = await _bir.Get();
            var aa = new List<BasketItemView>();

            result.ForEach(x => aa.Add(BasketItemViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.ProductId.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketItemView>> GetBasketItem(string id)
        {
            var basketItem = await _bir.Get(id);

            if (basketItem == null)
            {
                return NotFound();
            }

            return BasketItemViewFactory.Create(basketItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketItem(string id, BasketItemView basketItem)
        {
            if (id != basketItem.BasketId)
            {
                return BadRequest();
            }

            await _bir.Update(BasketItemViewFactory.Create(basketItem));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BasketItemView>> PostBasketItem(string productId, BasketItemView basketItem)
        {
            //Product product = await _pr.Get(productId);
            //Basket basket = await _br.GetLatestForUser(User.Identity.Name);
            //await _bir.Add(basket, product);

            await _bir.Add(BasketItemViewFactory.Create(basketItem));
            return CreatedAtAction("GetBasketItem", new { id = basketItem.GetId() }, basketItem);
        }

        //[HttpPost]
        //public async Task<ActionResult<BasketItemView>> PostBasketItem(string productId, BasketItemView basketItem)
        //{
        //    Product product = _pr.Get(productId);
        //Basket basket = _br.GetLatestForUser(User.Identity.Name);
        //    BasketItem i = await _bir.Add(basket, product);
        //    //await _bir.Add(_bivf.Create(basketItem));

        //    return CreatedAtAction("GetBasketItem", new { id = basketItem.GetId() }, basketItem);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasketItem(string id)
        {
            await _bir.Delete(id);

            return NoContent();
        }
    }
}