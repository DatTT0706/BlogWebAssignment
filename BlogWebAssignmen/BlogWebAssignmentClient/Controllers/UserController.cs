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
    public class UserController : Controller
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private readonly string UserApi = "https://localhost:5001/api/User/";

        public UserController(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.BaseAddress = new Uri(UserApi);
            _client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(int id)
        {
            var response = await _client.GetAsync(UserApi+ "id?id="+id);
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var userDTO = JsonSerializer.Deserialize<UserDTO>(strData, options);

            int userId = GetUserId();

            response = await _client.GetAsync("https://localhost:5001/api/Post/Author/"+id);
            strData = await response.Content.ReadAsStringAsync();
            var postDtos = JsonSerializer.Deserialize<List<PostDTO>>(strData, options);
            ViewData["Token"] = userId;
            ViewData["Posts"] = postDtos;
            return View(userDTO);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var response = await _client.GetAsync(UserApi + "id?id=" + id);
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var userDTO = JsonSerializer.Deserialize<UserDTO>(strData, options);
            if (userDTO != null)
            {
                return View(userDTO);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Edit(UserDTO user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/User?id=" + user.Id.ToString());

                //HTTP POST
                var putTask = client.PutAsJsonAsync<UserDTO>("", user);
                putTask.Wait();

                var result = putTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    return Redirect("/User/Index/" + user.Id.ToString());
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(user);
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