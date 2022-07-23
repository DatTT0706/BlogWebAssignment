using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlogWebAssignment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("imageName")]
        public async Task<IActionResult> GetImageByName(string imageName)
        {
            string filePath = Path.Combine(_environment.ContentRootPath, "image", imageName);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    var image = System.IO.File.OpenRead(filePath);
                    string ex = Path.GetExtension(filePath);
                    return File(image,"image/"+ex);

                }
               
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }

        }

    }
}
