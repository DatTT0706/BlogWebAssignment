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

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private readonly ILogger<CategoryController> _logger;
        private MapperConfiguration config;
        private readonly PRN231_BlogContext _context;
        private IMapper mapper;

        public CategoryController(ILogger<CategoryController> logger,
            PRN231_BlogContext context)
        {
            _context = context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category cat)
        {
            try
            {
                _context.Categories.Add(cat);
                _context.SaveChanges();
                return Ok(cat);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Category cat)
        {
            try
            {
                Category cat1 = _context.Categories.FirstOrDefault(p => p.Id == id);
                if (cat1 == null)
                {
                    return NotFound();
                }
                cat1.MetaTitle = cat.MetaTitle;
                cat1.Title = cat.Title;
                cat1.Slug = cat.Slug;
                cat1.Content = cat.Content;
                cat1.ParentId = cat.ParentId;
                _context.Entry<Category>(cat1).State = EntityState.Detached;
                _context.Categories.Update(cat1);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CategoryDTO> cats;

            cats = _context.Categories.ProjectTo<CategoryDTO>(config).ToList();
            if (cats == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(cats);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            CategoryDTO cat;
            cat = _context.Categories.ProjectTo<CategoryDTO>(config).FirstOrDefault(x => x.Id == id);
            if (cat == null)
            {
                return NotFound(); // Response with status code: 404
            }
            return Ok(cat);
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
                    return BadRequest("Category is in use");

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
