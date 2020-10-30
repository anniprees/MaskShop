using AutoMapper;
using BlazorApp.Shared.Data;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a list of paginated products with a default page size of 10.
        /// </summary>
        [HttpGet]
        public PagedResult<Product> GetAll([FromQuery]string name, int page)
        {
            int pageSize = 10;
            if (name != null)
            {
                return _context.Products
                .Where(o => o.Name.Contains(name, System.StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(o => o.Id)
                .AsNoTracking()
                .GetPaged(page, pageSize);
            }
            else
            {
                return _context.Products
                  .OrderBy(o => o.Id)
                  .GetPaged(page, pageSize);
            }
        }

        /// <summary>
        /// Returns top 10 results for type-ahead UI function
        /// </summary>
        [HttpGet]
        [Route("TypeAhead")]
        public IEnumerable<Product> TypeAhead([FromQuery]string name)
        {
            if (name != null)
            {
                return _context.Products
                .Where(p => p.Name.Contains(name, System.StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(p => p.Id)
                .Take(10)
                .AsNoTracking();
            }
            else
            {
                return _context.Products
                  .OrderBy(p => p.Id)
                  .Take(10)
                  .AsNoTracking();
            }
        }

        /// <summary>
        /// Gets a specific product by Id.
        /// </summary>
        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetById(string id)
        {
            var item = _context.Products.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item = _context.Products
               .Single(o => o.Id == id);
            return item;
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Updates a product with a specific Id.
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(string id, Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products
                   .Single(or => or.Id == id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update Existing Product
                _context.Entry(existingProduct).CurrentValues.SetValues(product);

                _context.SaveChanges();

                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Deletes a specific product by Id.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}


