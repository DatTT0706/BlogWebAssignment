using BlogWebAssignmentClient.Security;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        private readonly string ImageApi = "https://localhost:5001/api/Image/";

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
            var postDtos = System.Text.Json.JsonSerializer.Deserialize<List<PostDTO>>(strData, options);
            return View("PostManagement", postDtos);
        }

        public async Task<IActionResult> TestView()
        {
            //_client.BaseAddress = new Uri(ImageApi);
            var response = await _client.GetAsync(ImageApi+ "imageName?imageName=tea.jpg");
            
            //required using Newtonsoft.Json;
            var strData = await response.Content.ReadAsStringAsync();
            var forumModel = JsonConvert.DeserializeObject<ImageDTO>(strData);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            //var postDtos = System.Text.Json.JsonSerializer.Deserialize<List<PostDTO>>(strData, options);
            return View("TestView", forumModel);
        }

        public IActionResult HidePost()
        {
            return null;
        }
    }
}
