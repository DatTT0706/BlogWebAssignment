using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
       
        private readonly ILogger<PostController> _logger;
        private MapperConfiguration config;
        private readonly PRN231_BlogContext _context;
        private IMapper mapper;

        public PostController(ILogger<PostController> logger,
            PRN231_BlogContext context)
        {
            _context = context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<PostDTO> posts;
            posts = _context.Posts.ProjectTo<PostDTO>(config).ToList();
            if (posts == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(posts);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            PostDTO post;
            post = _context.Posts.ProjectTo<PostDTO>(config).FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(post);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post Post)
        {
            if (id != Post.Id)
            {
                return BadRequest();
            }

            _context.Entry(Post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post Post)
        {
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = Post.Id }, Post);
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

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
