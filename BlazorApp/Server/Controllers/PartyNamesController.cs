//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MaskShop.Domain.Parties;
//using MaskShop.Facade.Parties;

//namespace BlazorApp.Server.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PartyNamesController : ControllerBase
//    {
//        private readonly IPartyNamesRepository _pr;

//        public PartyNamesController(IPartyNamesRepository pr)
//        {
//            _pr = pr;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<PartyNameView>>> GetPartyNames(string name)
//        {
//            var result = await _pr.Get();
//            var aa = new List<PartyNameView>();

//            result.ForEach(x => aa.Add(PartyNameViewFactory.Create(x)));

//            return name == null ? aa : aa.Where(x => x.LastName.ToLower().Contains(name.ToLower())).ToList();

//        }

//        //[HttpGet("pagination")]
//        //public async Task<ActionResult<List<PartyNameView>>> GetPaginated([FromQuery] PaginationDTO pagination)
//        //{
//        //    var result = await _pr.Get();
//        //    var aa = new List<PartyNameView>();
//        //    result.ForEach(x => aa.Add(PartyNameViewFactory.Create(x)));

//        //    var queryable = aa.AsQueryable();
//        //    if (name != null)
//        //    {
//        //        queryable = queryable.Where(x => x.LastName.Contains(name));
//        //    }

//        //    await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.PageSize);
//        //    return await queryable.Paginate(pagination).ToListAsync();
//        //}

//        [HttpGet("{id}")]
//        public async Task<ActionResult<PartyNameView>> GetPartyName(string id)
//        {
//            var partyName = await _pr.Get(id);

//            if (partyName == null)
//            {
//                return NotFound();
//            }

//            return PartyNameViewFactory.Create(partyName);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPartyName(string id, PartyNameView partyName)
//        {
//            if (id != partyName.Id)
//            {
//                return BadRequest();
//            }

//            await _pr.Update(PartyNameViewFactory.Create(partyName));

//            return NoContent();
//        }

//        [HttpPost]
//        public async Task<ActionResult<PartyNameView>> PostPartyName(PartyNameView partyName)
//        {
//            await _pr.Add(PartyNameViewFactory.Create(partyName));

//            return CreatedAtAction("GetPartyName", new { id = partyName.Id }, partyName);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeletePartyName(string id)
//        {
//            await _pr.Delete(id);

//            return NoContent();
//        }
//    }
//}
