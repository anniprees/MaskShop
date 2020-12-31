using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly IInventoryItemsRepository _pr;

        public InventoryItemsController(IInventoryItemsRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ActionResult<List<InventoryItemView>>> GetInventoryItems(string name)
        {
            var result = await _pr.Get();
            var aa = new List<InventoryItemView>();

            result.ForEach(x => aa.Add(InventoryItemViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.ProductId.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItemView>> GetInventoryItem(string id)
        {
            var InventoryItem = await _pr.Get(id);

            if (InventoryItem == null)
            {
                return NotFound();
            }

            return InventoryItemViewFactory.Create(InventoryItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(string id, InventoryItemView InventoryItem)
        {
            if (id != InventoryItem.Id)
            {
                return BadRequest();
            }

            await _pr.Update(InventoryItemViewFactory.Create(InventoryItem));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<InventoryItemView>> PostInventoryItem(InventoryItemView InventoryItem)
        {
            await _pr.Add(InventoryItemViewFactory.Create(InventoryItem));

            return CreatedAtAction("GetInventoryItem", new { id = InventoryItem.Id }, InventoryItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventoryItem(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
