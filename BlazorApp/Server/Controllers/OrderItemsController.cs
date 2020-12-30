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
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsRepository _oir;

        public OrderItemsController(IOrderItemsRepository oir)
        {
            _oir = oir;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemView>>> GetOrderItems(string name)
        {
            var result = await _oir.Get();
            var aa = new List<OrderItemView>();

            result.ForEach(x => aa.Add(OrderItemViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.OrderId.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemView>> GetOrderItem(string id)
        {
            var orderItem = await _oir.Get(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return OrderItemViewFactory.Create(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemView>> PostOrderItem(string orderId, OrderItemView orderItem)
        {
            //Product product = await _pr.Get(productId);
            //Basket basket = await _br.GetLatestForUser(User.Identity.Name);
            //await _bir.Add(basket, product);

            await _oir.Add(OrderItemViewFactory.Create(orderItem));
            return CreatedAtAction("GetOrderItem", new { id = orderItem.GetId() }, orderItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderItem(string id)
        {
            await _oir.Delete(id);

            return NoContent();
        }
    }
}
