using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using Microsoft.AspNetCore.Authorization;

namespace BlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _pr;

        public ProductsController(IProductsRepository pr)
        {
            _pr = pr;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<ProductView>>> GetProducts(string name)
        {
            var result = await _pr.Get();
            var aa = new List<ProductView>();

            result.ForEach(x => aa.Add(ProductViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductView>> GetProduct(string id)
        {
            var product = await _pr.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return ProductViewFactory.Create(product);
        }
        //TODO kas update
        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, ProductView product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _pr.Update(ProductViewFactory.Create(product));

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductView>> PostProduct(ProductView product)
        {
            await _pr.Add(ProductViewFactory.Create(product));

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }

        //private bool ProductExists(string id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}
    }
}
