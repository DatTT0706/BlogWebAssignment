using AutoMapper;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private MapperConfiguration config;
        private readonly PRN231_BlogContext _context;
        private IMapper mapper;

        public UserController(ILogger<UserController> logger,
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
            List<UserDTO> users;
            users = _context.Users.ProjectTo<UserDTO>(config).ToList();
            if (users == null)
            {
                return NotFound(); // Response with status code: 404
            }

            return Ok(users);
        }

        [HttpGet("id")]
        public IActionResult GetUserById(int id)
        {
            UserDTO user;
            user = _context.Users.Include(u => u.Role).ProjectTo<UserDTO>(config).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("name")]
        public IActionResult GetUserByName(string name)
        {
            List<UserDTO> users;
            users = _context.Users.ProjectTo<UserDTO>(config).Where(p => p.FirstName.Contains(name) || p.MiddleName.Contains(name) || p.LastName.Contains(name)).ToList();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        [HttpPost("Login")]
        public IActionResult Post(LoginDTO loginDTO)
        {
            UserDTO user;
            user = _context.Users.ProjectTo<UserDTO>(config).FirstOrDefault(u => u.Email ==loginDTO.Email  && u.PasswordHash == loginDTO.Password);
            user.Role = _context.Roles.ProjectTo<RoleDTO>(config).FirstOrDefault(r => r.RoleId == user.RoleId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                user.RegisteredAt = DateTime.Now;
                user.LastLogin = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Post(int id, User user)
        {
            try
            {
                User u = _context.Users.FirstOrDefault(u => u.Id == id);
                if (u == null)
                {
                    return NotFound();
                }
                _context.Entry<User>(u).State = EntityState.Detached;
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok();
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
                User user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                _context.Users.Remove(user);
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
