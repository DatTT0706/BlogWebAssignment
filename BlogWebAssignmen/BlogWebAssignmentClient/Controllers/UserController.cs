using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebAssignmentClient.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        private readonly string UserApi = "https://localhost:5001/api/User/";

        public UserController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(UserApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public IActionResult Index()
        {
            return View("UserProfile");
        }

        public IActionResult GetUserById(int id)
        {
            return View("UserProfile");
        }
    }
}