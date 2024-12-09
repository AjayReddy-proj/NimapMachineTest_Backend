using MachineTest.Data;
using MachineTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MachineTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MachineDbContext _db;

        public CategoryController(MachineDbContext db)
        {
            this._db = db;
        }
        [HttpGet]
        public IActionResult CategoryDetails()
        {
            var category =_db.Categories.ToList();
            return Ok(category);
                }
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return Ok(category);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategory([FromBody]Category upCategory, [FromRoute] int id)
        {
            var category = _db.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            
            category.CategoryName = upCategory.CategoryName;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return Ok(category);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var category = _db.Categories.Find(id);
            if(category == null)
            {
                return NotFound();

            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return Ok(category);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCategoryId(int id) {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


    }

}
