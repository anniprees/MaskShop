using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Orders;
using MaskShop.Facade.Orders;
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
        private readonly BasketItemViewFactory _bivf;

        public  BasketItemsController(IBasketItemsRepository bir, BasketItemViewFactory bivf)
        {
            _bir = bir;
            _bivf = bivf;
        }

        [HttpGet]
        public async Task<ActionResult<List<BasketItemView>>> GetBasketItems(string name)
        {
            var result = await _bir.Get();
            var aa = new List<BasketItemView>();

            result.ForEach(x => aa.Add(_bivf.Create(x)));

            return name == null ? aa : aa.Where(x => x.ProductName.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketItemView>> GetBasketItem(string id)
        {
            var basketItem = await _bir.Get(id);

            if (basketItem == null)
            {
                return NotFound();
            }

            return _bivf.Create(basketItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketItem(string id, BasketItemView basketItem)
        {
            if (id != basketItem.BasketId)
            {
                return BadRequest();
            }

            await _bir.Update(_bivf.Create(basketItem));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BasketItemView>> PostBasketItem(BasketItemView basketItem)
        {
            await _bir.Add(_bivf.Create(basketItem));

            return CreatedAtAction("GetBasketItem", new { id = basketItem.BasketId }, basketItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasketItem(string id)
        {
            await _bir.Delete(id);

            return NoContent();
        }
    }
}