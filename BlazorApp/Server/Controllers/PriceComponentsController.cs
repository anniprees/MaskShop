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

            return name == null ? aa : aa.Where(x => x.Comment.ToLower().Contains(name.ToLower())).ToList();

        }

        //[HttpGet("pagination")]
        //public async Task<ActionResult<List<PriceComponentView>>> GetPaginated([FromQuery] PaginationDTO pagination)
        //{
        //    var result = await _pr.Get();
        //    var aa = new List<PriceComponentView>();
        //    result.ForEach(x => aa.Add(PriceComponentViewFactory.Create(x)));

        //    var queryable = aa.AsQueryable();
        //    if (name != null)
        //    {
        //        queryable = queryable.Where(x => x.Comment.Contains(name));
        //    }

        //    await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.PageSize);
        //    return await queryable.Paginate(pagination).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceComponentView>> GetPriceComponent(string id)
        {
            var priceComponent = await _pr.Get(id);

            if (priceComponent == null)
            {
                return NotFound();
            }

            return PriceComponentViewFactory.Create(priceComponent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceComponent(string id, PriceComponentView priceComponent)
        {
            if (id != priceComponent.Id)
            {
                return BadRequest();
            }

            await _pr.Update(PriceComponentViewFactory.Create(priceComponent));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PriceComponentView>> PostPriceComponent(PriceComponentView priceComponent)
        {
            await _pr.Add(PriceComponentViewFactory.Create(priceComponent));

            return CreatedAtAction("GetPriceComponent", new { id = priceComponent.Id }, priceComponent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePriceComponent(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
