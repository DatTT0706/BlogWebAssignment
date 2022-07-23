
using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private MapperConfiguration config;
        private readonly PRN231_BlogContext _context;
        private IMapper mapper;

        public CommentController(MapperConfiguration config, PRN231_BlogContext context, IMapper mapper)
        {
            this.config = config;
            _context = context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet("postid")]
        public async Task<ActionResult> GetCommentByPost(int postid)
        {
            var comments = await _context.PostComments.Where(c => c.PostId == postid).ProjectTo<CommentDTO>(config).ToListAsync();
            if (comments == null || comments.Count == 0) return NotFound();

            return Ok(comments);
        }

        [HttpDelete("commentId")]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            try
            {
                var comment = await _context.PostComments.FindAsync(commentId);
                _context.Remove(comment);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> SaveComment(CommentDTO comment)
        {
            try
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateComment(PostComment comment)
        {
            try
            {
                var updateItem = _context.Entry<PostComment>(comment);
                updateItem.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return BadRequest();
            }
        }
    }
}
