using BlogWebAssignmentClient.Security;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogWebAssignmentClient.Controllers
{
    public class AdminActionController : Controller
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly string PostApi = "https://localhost:5001/api/Post/";

        public AdminActionController(IConfiguration config, ITokenService tokenService)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(PostApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _config = config;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> PostManagement()
        {
            var response = await _client.GetAsync(PostApi);
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var postDtos = JsonSerializer.Deserialize<List<PostDTO>>(strData, options);
            return View("PostManagement", postDtos);
        }

        public IActionResult HidePost()
        {
            return null;
        }
    }
}
