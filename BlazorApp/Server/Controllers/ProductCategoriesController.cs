using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaskShop.Domain.Products;
using MaskShop.Facade.Products;
using MaskShop.Pages.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesRepository _pr;
        private readonly IProductCategoriesPage _service;

        public ProductCategoriesController(IProductCategoriesRepository pr, IProductCategoriesPage page)
        {
            _pr = pr;
            _service = page;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryView>>> GetProductCategories(string name)
        {
            var result = await _pr.Get();
            var aa = new List<ProductCategoryView>();

            result.ForEach(x => aa.Add(ProductCategoryViewFactory.Create(x)));

            return name == null ? aa : aa.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryView>> GetProductCategory(string id)
        {
            var category = await _pr.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return ProductCategoryViewFactory.Create(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(string id, ProductCategoryView category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await _pr.Update(ProductCategoryViewFactory.Create(category));

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryView>> PostProductCategory(ProductCategoryView category)
        {
            await _pr.Add(ProductCategoryViewFactory.Create(category));

            return CreatedAtAction("GetProductCategory", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductCategory(string id)
        {
            await _pr.Delete(id);

            return NoContent();
        }
    }
}
