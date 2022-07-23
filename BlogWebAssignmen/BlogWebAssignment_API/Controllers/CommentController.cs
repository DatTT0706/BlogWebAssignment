
using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

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
            this.mapper = mapper;
        }

        //[HttpGet("postId")]
        //public async Task<IEnumerable<CommentDTO>> GetPostComment(int postId)
        //{

        //}
    }
}
