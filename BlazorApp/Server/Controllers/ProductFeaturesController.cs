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
    public class ProductFeaturesController : ControllerBase
    {
        private readonly IProductFeaturesRepository _pr;

        public ProductFeaturesController(IProductFeaturesRepository pr)
        {
            _pr = pr;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductFeatureView>>> GetProductFeatures(string name)
        {
            var result = await _pr.Get();
            var aa = new List<ProductFeatureView>();

            result.ForEach(x => aa.Add(ProductFeatureViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductFeatureView>> GetProductFeature(string id)
        {
            var ProductFeature = await _pr.Get(id);

            if (ProductFeature == null)
            {
                return NotFound();
            }

            return ProductFeatureViewFactory.Create(ProductFeature);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductFeature(string id, ProductFeatureView ProductFeature)
        {
            if (id != ProductFeature.Id)
            {
                return BadRequest();
            }

            await _pr.Update(ProductFeatureViewFactory.Create(ProductFeature));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductFeatureView>> PostProductFeature(ProductFeatureView ProductFeature)
        {
            await _pr.Add(ProductFeatureViewFactory.Create(ProductFeature));

            return CreatedAtAction("GetProductFeature", new { id = ProductFeature.Id }, ProductFeature);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductFeature(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
