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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepo;

        public OrdersController(IOrdersRepository ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderView>>> GetOrders(string name)
        {
            var result = await _ordersRepo.Get();
            var aa = new List<OrderView>();

            result.ForEach(x => aa.Add(OrderViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Id.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderView>> GetOrder(string id)
        {
            var order = await _ordersRepo.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return OrderViewFactory.Create(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, OrderView order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _ordersRepo.Update(OrderViewFactory.Create(order));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<OrderView>> PostOrder(string orderId, OrderView order)
        {
            //Product product = await _pr.Get(productId);
            //Basket basket = await _br.GetLatestForUser(User.Identity.Name);
            //await _bir.Add(basket, product);

            await _ordersRepo.Add(OrderViewFactory.Create(order));
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            await _ordersRepo.Delete(id);

            return NoContent();
        }
    }
}
