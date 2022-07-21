using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
       
        private readonly ILogger<TagController> _logger;
        private readonly PRN231_BlogContext _context;

        public TagController(ILogger<TagController> logger,
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
                var tag = _context.Tags.FirstOrDefault(x=>x.Id == id);
                if (tag == null)
                {
                    return NotFound();
                }

                var post_cats = _context.PostTags.Where(x => x.TagId == id);
                if (post_cats.Any())
                {
                    return Ok("Tag is in use");
                }
                else
                {
                    _context.Tags.Remove(tag);
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
