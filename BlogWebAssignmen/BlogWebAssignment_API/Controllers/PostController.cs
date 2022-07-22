using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        int page = 0;

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

        [HttpGet("page")]
        public async Task<ActionResult> GetPostByPage(int page)
        {
            List<PostDTO> posts = await _context.Posts.ProjectTo<PostDTO>(config).ToListAsync();
            if (posts == null) return NotFound();
            return Ok(GetPostPage(10,page,posts));

        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            PostDTO post;
            post = _context.Posts.ProjectTo<PostDTO>(config).FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(post);
        }


        [HttpPost("title")]
        public async Task<ActionResult> SearchPostByName(string title,int page)
        {
            List<PostDTO> posts = await _context.Posts.Where(p => p.Title.Contains(title)).ProjectTo<PostDTO>(config).ToListAsync();
            if (posts == null) return NotFound();
            return Ok(GetPostPage(10, page, posts));
        }

        [HttpPost("PostByTag")]
        public async Task<ActionResult> GetPostByTag(Tag tagList) 
        {
            List<PostDTO> posts = await _context.Posts.Where(p => p.).ProjectTo<PostDTO>(config).ToListAsync();
            if (posts == null) return NotFound();
            return Ok(GetPostPage(10, page, posts));
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _context.Posts.FirstOrDefault(x => x.Id == id);
                if (post == null)
                {
                    return NotFound();
                }

                var post_tags = _context.PostTags.Where(x => x.PostId == id);
                var post_cats = _context.PostCategories.Where(x => x.PostId == id);
                var post_coms = _context.PostComments.Where(x => x.PostId == id);

                if (post_cats != null) _context.PostCategories.RemoveRange(post_cats);
                if (post_tags != null) _context.PostTags.RemoveRange(post_tags);
                if (post_coms != null) _context.PostComments.RemoveRange(post_coms);

                _context.Posts.Remove(post);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private IEnumerable<PostDTO> GetPostPage(int pageSize, int index, IEnumerable<PostDTO> input)
        {
            int startIndex = (index - 1) * 10;
            var postInPage = input.Skip(startIndex).Take(pageSize);
            return postInPage;
        }

    }
}
