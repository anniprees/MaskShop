using System;
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
    public class PriceComponentsController : ControllerBase
    {
        private readonly IPriceComponentsRepository _pr;

        public PriceComponentsController(IPriceComponentsRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ActionResult<List<PriceComponentView>>> GetPriceComponents(string name)
        {
            var result = await _pr.Get();
            var aa = new List<PriceComponentView>();

            result.ForEach(x => aa.Add(PriceComponentViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.PartyRoleId.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceComponentView>> GetPriceComponent(string id)
        {
            var category = await _pr.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return PriceComponentViewFactory.Create(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceComponent(string id, PriceComponentView category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await _pr.Update(PriceComponentViewFactory.Create(category));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PriceComponentView>> PostPriceComponent(PriceComponentView category)
        {
            await _pr.Add(PriceComponentViewFactory.Create(category));

            return CreatedAtAction("GetPriceComponent", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePriceComponent(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
