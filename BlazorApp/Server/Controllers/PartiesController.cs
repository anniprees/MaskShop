using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MaskShop.Domain.Parties;
using MaskShop.Facade.Parties;

namespace BlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        private readonly IPartiesRepository _pr;

        public PartiesController(IPartiesRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ActionResult<List<PartyView>>> GetParties(string name)
        {
            var result = await _pr.Get();
            var aa = new List<PartyView>();

            result.ForEach(x => aa.Add(PartyViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

        }

        //[HttpGet("pagination")]
        //public async Task<ActionResult<List<PartyView>>> GetPaginated([FromQuery] PaginationDTO pagination)
        //{
        //    var result = await _pr.Get();
        //    var aa = new List<PartyView>();
        //    result.ForEach(x => aa.Add(PartyViewFactory.Create(x)));

        //    var queryable = aa.AsQueryable();
        //    if (name != null)
        //    {
        //        queryable = queryable.Where(x => x.PartyNameId.Contains(name));
        //    }

        //    await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.PageSize);
        //    return await queryable.Paginate(pagination).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PartyView>> GetParty(string id)
        {
            var party = await _pr.Get(id);

            if (party == null)
            {
                return NotFound();
            }

            return PartyViewFactory.Create(party);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParty(string id, PartyView party)
        {
            if (id != party.Id)
            {
                return BadRequest();
            }

            await _pr.Update(PartyViewFactory.Create(party));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PartyView>> PostParty(PartyView party)
        {
            await _pr.Add(PartyViewFactory.Create(party));

            return CreatedAtAction("GetParty", new { id = party.Id }, party);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParty(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
