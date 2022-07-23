using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BlogWebAssignmentClient.Models;
using BlogWebAssignmentClient.Security;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;

namespace BlogWebAssignmentClient.Controllers
{
    public class PostContentController : Controller
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private readonly string UserApi = "https://localhost:5001/api/PostContent/";

        public PostContentController(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(UserApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
        }
        public async Task<IActionResult> Index()
        {
            if(GetUserId() == -1)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["publisher"] = GetUserId();
            return View();
        }
        [HttpPost]
        public IActionResult PostContent(PostDTO post)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/Post");
                post.AuthorId = GetUserId();
                var putTask = client.PostAsJsonAsync<PostDTO>("", post);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Sum ting gong. Please try again!");
            return View("Index", post);
        }
        public int GetUserId()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var SecretKey = _config["Jwt:Key"].ToString();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var token = HttpContext.Session.GetString("Token");

            if (token != null)
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                return int.Parse(jwtToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            }
            return -1;
        }
    }
}