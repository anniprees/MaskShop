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
    public class ContactMechanismsController : ControllerBase
    {
        private readonly IContactMechanismsRepository _pr;

        public ContactMechanismsController(IContactMechanismsRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactMechanismView>>> GetContactMechanisms(string name)
        {
            var result = await _pr.Get();
            var aa = new List<ContactMechanismView>();

            result.ForEach(x => aa.Add(ContactMechanismViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Street.ToLower().Contains(name.ToLower())).ToList();

        }

        //[HttpGet("pagination")]
        //public async Task<ActionResult<List<ContactMechanismView>>> GetPaginated([FromQuery] PaginationDTO pagination)
        //{
        //    var result = await _pr.Get();
        //    var aa = new List<ContactMechanismView>();
        //    result.ForEach(x => aa.Add(ContactMechanismViewFactory.Create(x)));

        //    var queryable = aa.AsQueryable();
        //    if (name != null)
        //    {
        //        queryable = queryable.Where(x => x.Street.Contains(name));
        //    }

        //    await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.PageSize);
        //    return await queryable.Paginate(pagination).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMechanismView>> GetContactMechanism(string id)
        {
            var contactMechanism = await _pr.Get(id);

            if (contactMechanism == null)
            {
                return NotFound();
            }

            return ContactMechanismViewFactory.Create(contactMechanism);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactMechanism(string id, ContactMechanismView contactMechanism)
        {
            if (id != contactMechanism.Id)
            {
                return BadRequest();
            }

            await _pr.Update(ContactMechanismViewFactory.Create(contactMechanism));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ContactMechanismView>> PostContactMechanism(ContactMechanismView contactMechanism)
        {
            await _pr.Add(ContactMechanismViewFactory.Create(contactMechanism));

            return CreatedAtAction("GetContactMechanism", new { id = contactMechanism.Id }, contactMechanism);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactMechanism(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
