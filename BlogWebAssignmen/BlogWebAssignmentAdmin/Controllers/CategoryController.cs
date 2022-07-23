using BlogWebAssignmentAdmin.Security;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogWebAssignmentAdmin.Controllers
{
    public class CategoryController : Controller
    {
        public User Author { get; set; }
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly string PostApi = "https://localhost:5001/api/Category/";
        public CategoryController(IConfiguration config, ITokenService tokenService)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(PostApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _config = config;
            _tokenService = tokenService;
        }
        public async Task<ActionResult> Index()
        {
            var response = await _client.GetAsync(PostApi);
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var postDtos = JsonSerializer.Deserialize<List<CategoryDTO>>(strData, options);
            return View(postDtos);
        }


    }
}