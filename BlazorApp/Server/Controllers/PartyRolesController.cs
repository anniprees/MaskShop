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
    public class PartyRolesController : ControllerBase
    {
        private readonly IPartyRolesRepository _pr;

        public PartyRolesController(IPartyRolesRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ActionResult<List<PartyRoleView>>> GetPartyRoles(string name)
        {
            var result = await _pr.Get();
            var aa = new List<PartyRoleView>();

            result.ForEach(x => aa.Add(PartyRoleViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Role.ToLower().Contains(name.ToLower())).ToList();

        }

        //[HttpGet("pagination")]
        //public async Task<ActionResult<List<PartyRoleView>>> GetPaginated([FromQuery] PaginationDTO pagination)
        //{
        //    var result = await _pr.Get();
        //    var aa = new List<PartyRoleView>();
        //    result.ForEach(x => aa.Add(PartyRoleViewFactory.Create(x)));

        //    var queryable = aa.AsQueryable();
        //    if (name != null)
        //    {
        //        queryable = queryable.Where(x => x.Role.Contains(name));
        //    }

        //    await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.PageSize);
        //    return await queryable.Paginate(pagination).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PartyRoleView>> GetPartyRole(string id)
        {
            var partyRole = await _pr.Get(id);

            if (partyRole == null)
            {
                return NotFound();
            }

            return PartyRoleViewFactory.Create(partyRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartyRole(string id, PartyRoleView partyRole)
        {
            if (id != partyRole.Id)
            {
                return BadRequest();
            }

            await _pr.Update(PartyRoleViewFactory.Create(partyRole));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PartyRoleView>> PostPartyRole(PartyRoleView partyRole)
        {
            await _pr.Add(PartyRoleViewFactory.Create(partyRole));

            return CreatedAtAction("GetPartyRole", new { id = partyRole.Id }, partyRole);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePartyRole(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
