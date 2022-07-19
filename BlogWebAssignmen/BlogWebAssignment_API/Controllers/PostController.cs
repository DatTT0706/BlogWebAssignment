using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
       
        private readonly ILogger<PostController> _logger;
        private readonly PRN231_BlogContext _context;

        public PostController(ILogger<PostController> logger,
            PRN231_BlogContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _context.Posts.ToList();
            if (posts == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(posts);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var post = _context.Posts.FirstOrDefault(x=>x.Id == id);
            if (post == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(post);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _context.Posts.FirstOrDefault(x=>x.Id == id);
                if (post == null)
                {
                    return NotFound();
                }

                var post_tags = _context.PostTags.Where(x => x.PostId == id);
                var post_cats = _context.PostCategories.Where(x => x.PostId == id);
                var post_coms = _context.PostComments.Where(x => x.PostId == id);

                if(post_cats != null) _context.PostCategories.RemoveRange(post_cats);
                if(post_tags != null) _context.PostTags.RemoveRange(post_tags);
                if(post_coms != null) _context.PostComments.RemoveRange(post_coms);

                _context.Posts.Remove(post);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
