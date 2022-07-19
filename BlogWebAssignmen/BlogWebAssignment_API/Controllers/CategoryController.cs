using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private readonly ILogger<CategoryController> _logger;
        private readonly PRN231_BlogContext _context;

        public CategoryController(ILogger<CategoryController> logger,
            PRN231_BlogContext context)
        {
            _context = context;
            _logger = logger;
        }

        
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cat = _context.Categories.FirstOrDefault(x=>x.Id == id);
                if (cat == null)
                {
                    return NotFound();
                }
                var post_cats = _context.PostCategories.Where(x => x.CategoryId == id);
                if (post_cats.Any())
                {
                    return Ok("Category is in use");

                }
                else
                {
                    _context.Categories.Remove(cat);
                    _context.SaveChanges();
                    return Ok();
                }
            
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
