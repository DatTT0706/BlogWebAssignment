using BlogWebAssignmentClient.Security;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlogWebAssignmentClient.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private readonly HttpClient _client;
        private readonly string UserApi = "https://localhost:5001/api/User/";

        public LoginController(IConfiguration config, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _config = config;
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(UserApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(UserDTO userModel)
        {
            if (string.IsNullOrEmpty(userModel.Email) || string.IsNullOrEmpty(userModel.PasswordHash))
            {
                return (RedirectToAction("Error"));
            }
            IActionResult response = Unauthorized();
            var validUser = GetUser(userModel);

            if (validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return RedirectToAction("Index", "Home");
                    
                    
                }
                else
                {
                    return (RedirectToAction("Error"));
                }
            }
            else
            {
                return (RedirectToAction("Error"));
            }
        }

        private UserDTO GetUser(UserDTO userModel)
        {



            var content = new LoginDTO();
            content.Email = userModel.Email;
            content.Password= userModel.PasswordHash;
            
            UserDTO user = null;
            var responseTask = _client.PostAsJsonAsync<LoginDTO>("Login", content);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<UserDTO>();
                readTask.Wait();
                user = readTask.Result;
            }
            return user;
        }

        [Authorize]       
        [HttpGet]
        public IActionResult MainWindow()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Index"));
            }
            if (!_tokenService.ValidateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("Index"));
            }
            ViewBag.Message = BuildMessage(token, 50);
            return RedirectToAction("Index", "HomeController");
        }

        public IActionResult Error()
        {
            //ViewBag.Message = "An error occured...";
            return View();
        }

        private string BuildMessage(string stringToSplit, int chunkSize)
        {
            var data = Enumerable.Range(0, stringToSplit.Length / chunkSize).Select(i => stringToSplit.Substring(i * chunkSize, chunkSize));
            string result = "The generated token is:";
            foreach (string str in data)
            {
                result += Environment.NewLine + str;
            }
            return result;
        }
    }
}
