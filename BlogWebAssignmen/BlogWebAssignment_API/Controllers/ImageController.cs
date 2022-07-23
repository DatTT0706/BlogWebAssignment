using DataAccess.DTO;
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
            ImageDTO imgDto = new ImageDTO();
            string filePath = Path.Combine(_environment.ContentRootPath, "image", imageName);

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    var image = System.IO.File.OpenRead(filePath);
                    string ex = Path.GetExtension(filePath);
                    imgDto.Content = System.IO.File.ReadAllBytes("image/"+imageName);

                    //return File(image,"image/"+ex);
                    return Ok(imgDto);

                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }

        }

        public static byte[] ToByteArray(Stream stream)
        {
            using (stream)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }

    }
}
