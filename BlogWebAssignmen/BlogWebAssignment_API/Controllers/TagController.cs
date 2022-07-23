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
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;
        private readonly PRN231_BlogContext _context;
        private MapperConfiguration config;
        private IMapper mapper;

        public TagController(ILogger<TagController> logger,
            PRN231_BlogContext context)
        {
            _context = context;
            _logger = logger;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAll()
        {
            try
            {
                var tagList = await _context.Tags.ProjectTo<TagDTO>(config).ToListAsync();
                if (tagList == null) return NotFound();
                return Ok(tagList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTagById(string id)
        {
            try
            {
                int mId = Int32.Parse(id);
                var tag = await _context.Tags.ProjectTo<TagDTO>(config).FirstOrDefaultAsync(t => t.Id == mId);
                if (tag == null) return NotFound();
                return Ok(tag);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Tag>> GetTagByName(string name)
        {
            try
            {
                var tag = await _context.Tags.ProjectTo<TagDTO>(config).FirstOrDefaultAsync(t => t.Title == name);
                if (tag == null) return NotFound();
                return Ok(tag);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var tag = _context.Tags.FirstOrDefault(x => x.Id == id);
                if (tag == null)
                {
                    return NotFound();
                }

                var post_cats = _context.PostTags.Where(x => x.TagId == id);
                if (post_cats.Any())
                {
                    return BadRequest("Tag is in use");
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

        [HttpGet("PostTag/{postId}")]
        public async Task<ActionResult<PostTag>> GetTagsByPostId(int postId)
        {
            var posTag = await _context.PostTags
                .Include(x => x.Post)
                .Include(x => x.Tag)
                .Where(x => x.PostId == postId)
                .ToListAsync();
            return Ok(posTag);
        }
    }
}