using MachineTest.Data;
using MachineTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MachineDbContext _db;

        public ProductController(MachineDbContext db)
        {
            this._db = db;
        }
        [HttpGet]
        public IActionResult ProductDetails()
        {
            var product = _db.Products.ToList();
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok(product);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct([FromBody] Product upProduct, [FromRoute] int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductName = upProduct.ProductName;
            product.CategoryId = upProduct.CategoryId;
            product.CategoryName = upProduct.CategoryName;
            _db.Products.Update(product);
            _db.SaveChanges();
            return Ok(product);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _db.Products.Find(id);
            if ( product == null)
            {
                return NotFound();

            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok(product);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductId(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
