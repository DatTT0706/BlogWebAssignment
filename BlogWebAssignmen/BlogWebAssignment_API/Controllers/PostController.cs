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
        private IMapper _mapper;

        public PostController(ILogger<PostController> logger,
            PRN231_BlogContext context)
        {
            _context = context;
            config = new MapperConfiguration(cfg =>
                cfg.AddProfile(new MapperProfile()));
            _mapper = config.CreateMapper();
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<PostDTO> posts;
            posts = _context.Posts.Include(p => p.Author).ProjectTo<PostDTO>(config).ToList();
            return Ok(posts);
        }

        [HttpGet("page")]
        public async Task<ActionResult> GetPostByPage(int page)
        {
            List<PostDTO> posts = await _context.Posts.ProjectTo<PostDTO>(config).ToListAsync();
            if (posts == null) return NotFound();
            return Ok(GetPostPage(10, page, posts));
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
        public async Task<ActionResult> SearchPostByName(string title, int page)
        {
            List<PostDTO> posts = await _context.Posts.Where(p => p.Title.Contains(title)).ProjectTo<PostDTO>(config)
                .ToListAsync();
            if (posts == null) return NotFound();
            return Ok(GetPostPage(10, page, posts));
        }

        [HttpPost("PostByCategoryAndTag/{page}")]
        public async Task<ActionResult> GetByTagCategory(int page,[FromQuery]List<CategoryDTO>? categoryList, [FromQuery] List<TagDTO> tagList)
        {
            List<PostDTO> result = await _context.Posts.ProjectTo<PostDTO>(config).ToListAsync();
            bool isCategoryListEmpty = categoryList == null || categoryList.Count == 0;
            if (!isCategoryListEmpty)
            {
                foreach (var category in categoryList)
                {
                    List<PostCategory> mapping = await _context.PostCategories.Where(pc => pc.CategoryId == category.Id)
                        .ToListAsync();
                    List<int> input = mapping.Select(pc => pc.PostId).ToList();
                    result = SortPostList(result, input).ToList();
                }
            }

            bool isTagListEmpty = tagList == null || tagList.Count == 0;
            if (!isTagListEmpty)
            {
                foreach (var tag in tagList)
                {
                    List<PostTag> mapping = await _context.PostTags.Where(pc => pc.TagId == tag.Id).ToListAsync();
                    List<int> input = mapping.Select(pc => pc.PostId).ToList();
                    result = SortPostList(result, input).ToList();
                }
            }

            int pageSize = 10;

            return Ok(GetPostPage(pageSize, page, result));
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

        private IEnumerable<PostDTO> SortPostList(IEnumerable<PostDTO> posts, List<int> idList)
        {
            List<PostDTO> postList = posts.Where(p => idList.Contains(p.Id)).ToList();
            return postList;
        }

        [HttpGet("PostCategory/{categoryId}")]
        public async Task<ActionResult<PostCategory>> GetByCategoryId(int categoryId)
        {
            var postCategoryDto = await _context.PostCategories
                .Include(x => x.Post)
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .Select(x => x.Post)
                .ToListAsync();
            return Ok(postCategoryDto);
        }

        [HttpGet("Post/Author/{authorId}")]
        public async Task<ActionResult> GetPostByAuthor(int authorId)
        {
            var posts = await _context.Posts.Where(p => p.AuthorId == authorId).ProjectTo<PostDTO>(config).ToListAsync();
            return Ok(posts);
        }
    }
}