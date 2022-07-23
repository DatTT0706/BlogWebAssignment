using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BlogWebAssignmentClient.Models;
using DataAccess.DTO;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebAssignmentClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly string PostApi = "https://localhost:5001/api/Post/";

        public HomeController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(PostApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync(PostApi);
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var postDtos = JsonSerializer.Deserialize<List<PostDTO>>(strData, options);
            return View(postDtos);
        }

        public async Task<ActionResult> OnGetPostDetail(int id)
        {
            PostDTO post = null;
            var responseTask = _client.GetAsync($"id?id={id.ToString()}");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<PostDTO>();
                readTask.Wait();
                post = readTask.Result;
            }

            return View("PostDetail", post);
        }

        public async Task<ActionResult> OnGetPostByCategoryId(int id)
        {
            var response = await _client.GetAsync($"PostCategory/{id}");
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var postDtos = JsonSerializer.Deserialize<List<PostCategory>>(strData, options);
            return View("CategoryDetail", postDtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}