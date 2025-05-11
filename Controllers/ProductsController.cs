using Microsoft.AspNetCore.Mvc;
using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ProductsController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;
            product.Price = updatedProduct.Price;
            product.ExpiryDate = updatedProduct.ExpiryDate;
            product.Category = updatedProduct.Category;

            _context.SaveChanges();
            return Ok(product);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

// using Microsoft.AspNetCore.Mvc;
// using InventoryService.Data;
// using InventoryService.Models;
// using System.Collections.Generic;
// using System.Linq;

// namespace InventoryService.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ProductsController : ControllerBase
//     {
//         private readonly InventoryContext _context;

//         public ProductsController(InventoryContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public ActionResult<IEnumerable<Product>> Get()
//         {
//             return _context.Products.ToList();
//         }

//         [HttpPost]
//         public IActionResult Add(Product product)
//         {
//             _context.Products.Add(product);
//             _context.SaveChanges();
//             return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
//         }
//     }
// }
